using Re.C.IR;
using Re.C.Types;

namespace Re.C.Passes;

public class DropAnalysis(RecContext ctx) : IRPass(ctx)
{
    public override void Perform(IRFunction fn)
    {
        // TODO: real logging //
        Console.WriteLine(fn.ToIRString());
    }

    private void TryMoveValue(
        InstructionBlock block, 
        Instruction mover, 
        ValueID value, 
        bool throughPointer,
        bool emitErrors)
    {
        // Ignore leaked values entirely //
        if(block.LeakedValues.Contains(value))
            return;

        var argInst = block.Function.InstructionByValue(value);
        var argType = throughPointer ? argInst.Type.Deref.Unwrap() : argInst.Type;
        
        block.DropAtEnd.Remove(value);

        // Throw error on use after move 
        // (note that it is illegal to move in a potentially recursive block)
        if(emitErrors)
        {
            var moved = block.MovedValues.TryGetValue(value, out var moveLocation);
            if(!moved)
                moveLocation = mover.Span;

            if(block.CanRecurse || moved)
            {
                CTX.Diagnostics.AddError(
                    mover.Span,
                    Errors.UseAfterMove());

                // TODO: class for 'infos' / better way to handle this
                CTX.Diagnostics.AddInfo(
                    moveLocation,
                    $"Value was moved from here");

                return;
            }
        }

        // Mark as moved if not leaked and not copyable
        if(!argType.TriviallyCopyable)
        {
            block.MovedValues.TryAdd(value, mover.Span);
        }
    }

    protected override void VisitBlock(InstructionBlock block)
    {
        // Merge all moved values down to this block
        var needsPartialDropCoverage = Temporary.Dictionary<ValueID, DropMethod>();

        foreach(var antecedent in block.Antecedents)
        {
            // Merge moved values into this block
            foreach(var kvp in antecedent.MovedValues)
            {
                block.MovedValues[kvp.Key] = kvp.Value;

                foreach(var otherAntecedent in block.Antecedents)
                {
                    if(otherAntecedent.DropAtEnd.TryGetValue(kvp.Key, out var method))
                    {
                        needsPartialDropCoverage.Value.Add(kvp.Key, method);
                        break;
                    }
                }
            }

            // Add all values not yet dropped
            foreach(var kvp in antecedent.DropAtEnd)
                block.DropAtEnd.Add(kvp.Key, kvp.Value);

            // Merge all leaked values 
            block.LeakedValues.UnionWith(antecedent.LeakedValues);
        }

        int OrderKey(KeyValuePair<ValueID, DropMethod> kvp)
            => block.Function.InstructionByValue(kvp.Key).Span.Start.Index;

        // Drop all values needing partial drop coverage
        CTX.IRBuilder.PositionAfterLastPhi(block);
        foreach(var (value, method) in needsPartialDropCoverage.Value.OrderBy(OrderKey))
        {
            CTX.IRBuilder.Build(
                CTX.BuiltinTypes.None, SourceSpan.Builtin,
                new InstructionKind.Drop(value, true, method));
        }

        needsPartialDropCoverage.Dispose();

        // Iterate all instructions
        for(var i = 0; i < block.InstructionCount; i++)
        {
            var inst = block.Instructions[i];

            using var args = Temporary.List<ValueID>();
            inst.Kind.GetArguments(args.Value);

            // General drop analysis; move all arguments (unless copied or leaked) //
            foreach(var arg in args.Value)
            {
                TryMoveValue(block, inst, arg, throughPointer: false, emitErrors: true);
            }

            // General drop analysis: drop (nonleaked) return values of instructions directly if not copyable //
            if(!inst.Type.TriviallyCopyable)
            {
                block.DropAtEnd.Add(inst.ValueID.Unwrap(), DropMethod.Direct);
            }

            // Special cases //
            // Local declarations; mark result as a drop-via-pointer type
            if(inst.Kind is InstructionKind.Local local)
            {
                if(!block.Function.InstructionByValue(local.Value).Type.TriviallyCopyable)
                    block.DropAtEnd.Add(inst.ValueID.Unwrap(), DropMethod.ThroughPointer);
            }

            // Array declarations; drop elements inside array
            if(inst.Kind is InstructionKind.ArrayLiteral arr && !arr.Construction.MatchesRaw)
            {
                if(!inst.Type.Element.Unwrap().TriviallyCopyable)
                    block.DropAtEnd.Add(inst.ValueID.Unwrap(), DropMethod.ThroughArray);
            }

            // Stores; drop existing value before assigning
            if(inst.Kind is InstructionKind.Store store && !store.Uninit)
            {
                if(block.Function.InstructionByValue(store.Value).Type.TriviallyCopyable)
                {
                    block.InsertInstruction(i, new Instruction(
                        CTX.BuiltinTypes.None, inst.Span,
                        new InstructionKind.Drop(store.Ptr, false, DropMethod.ThroughPointer)));

                    i++;
                }
            }

            // Load; error if not copyable (illegal to move out of (non-local) reference)
            //     ; and mark as moved if loading from pointer
            if(inst.Kind is InstructionKind.Load load)
            {
                var ptrInst = block.Function.InstructionByValue(load.Ptr);
                if(ptrInst.Kind is InstructionKind.Local)
                {
                    TryMoveValue(block, inst, load.Ptr, throughPointer: true, emitErrors: false);
                }
                else if(ptrInst.Type is ReferenceType && !inst.Type.TriviallyCopyable)
                {
                    CTX.Diagnostics.AddError(
                        inst.Span,
                        Errors.MoveOutOfReference());
                }
            }

            // Leak; add result id to leaked values set
            if(inst.Kind is InstructionKind.Leak)
            {
                block.LeakedValues.Add(inst.ValueID.Unwrap());
                block.DropAtEnd.Remove(inst.ValueID.Unwrap());
            }
        }

        // Drop all values at end of block if ending a lexical block
        var shouldDropValues = false;
        foreach(var consequent in block.Consequents)
        {
            if(consequent.LexicalScope != block.LexicalScope)
            {
                shouldDropValues = true;
                break;
            }
        }

        if(shouldDropValues)
        {
            CTX.IRBuilder.PositionBeforeLastTerminal(block);

            foreach(var (value, method) in block.DropAtEnd.OrderBy(OrderKey))
            {
                CTX.IRBuilder.Build(
                    CTX.BuiltinTypes.None, SourceSpan.Builtin, 
                    new InstructionKind.Drop(value, true, method));
            }

            block.DropAtEnd.Clear();
        }
    }
}