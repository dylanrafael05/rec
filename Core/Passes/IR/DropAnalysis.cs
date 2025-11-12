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
        var argInst = block.Function.InstructionByValue(value);
        var argType = throughPointer ? argInst.Type.UnwrapAs<PointerType>().Pointee : argInst.Type;
        
        block.DropAtEnd.Remove(value);

        // Throw error on use after move
        if(emitErrors && block.MovedValues.TryGetValue(value, out var moveLocation))
        {
            // TODO: create a ValueRef class which wraps a ValueID and a SourceSpan
            //       denoting the exact position where it was referenced
            CTX.Diagnostics.AddError(
                mover.Span,
                Errors.UseAfterMove());

            // TODO: class for 'infos' / better way to handle this
            CTX.Diagnostics.AddInfo(
                moveLocation,
                $"Value was moved from here");

            return;
        }

        // Mark as moved if not leaked and not copyable
        if(!block.LeakedValues.Contains(value) && !argType.TriviallyCopyable)
        {
            block.MovedValues.TryAdd(value, mover.Span);
        }
    }

    protected override void VisitBlock(InstructionBlock block)
    {
        foreach(var antecedent in block.Antecedents)
        {
            foreach(var kvp in antecedent.MovedValues)
                block.MovedValues[kvp.Key] = kvp.Value;

            block.LeakedValues.UnionWith(antecedent.LeakedValues);
        }

        // TODO; inject 'partial drop' handling logic here

        // Iterate all instructions
        foreach(var inst in block.Instructions)
        {
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
            if(inst.Kind is InstructionKind.Local)
            {
                block.DropAtEnd.Add(inst.ValueID.Unwrap(), DropMethod.ThroughPointer);
            }

            // Stores; drop existing value before assigning
            if(inst.Kind is InstructionKind.Store store)
            {
                block.DropBeforeInstruction.Add((
                    inst, store.Value, DropMethod.ThroughPointer));
            }

            // Load; error if not copyable (illegal to move out of (non-local) reference)
            //     ; and mark as moved if loading from pointer
            if(inst.Kind is InstructionKind.Load load)
            {
                if(block.Function.VariableMappings.Contains(load.Ptr))
                {
                    TryMoveValue(block, inst, load.Ptr, throughPointer: true, emitErrors: false);
                }
                else if(!inst.Type.TriviallyCopyable)
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
            }
        }

        // TODO; inject drop code based on computed values

    }
}