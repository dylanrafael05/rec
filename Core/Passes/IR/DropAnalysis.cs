using Re.C.IR;

namespace Re.C.Passes;

public class DropAnalysis(RecContext ctx) : IRPass(ctx)
{
    public override void Perform(IRFunction fn)
    {
        // TODO: real logging //
        Console.WriteLine(fn.ToIRString());
    }

    protected override void VisitBlock(InstructionBlock block)
    {
        foreach(var antecedent in block.Antecedents)
        {
            // NOTE; how to mark/handle partially moved values? //
            foreach(var kvp in antecedent.MovedNamedValues)
                block.MovedNamedValues[kvp.Key] = kvp.Value;
        }

        // TODO; inject 'partial drop' handling logic here

        // Iterate all instructions
        foreach(var inst in block.Instructions)
        {
            using var args = Temporary.List<ValueID>();
            inst.Kind.GetArguments(args.Value);

            foreach(var arg in args.Value)
            {
                // TODO: there has to be a better way to do this
                block.DropAtEnd.Remove(DroppableValue.ViaPointer(arg));
                block.DropAtEnd.Remove(DroppableValue.ViaDirect(arg));

                // Throw error on use after move
                if(block.MovedNamedValues.ContainsKey(arg))
                {
                    // TODO: create a ValueRef class which wraps a ValueID and a SourceSpan
                    //       denoting the exact position where it was referenced
                    CTX.Diagnostics.AddError(
                        inst.Span,
                        Errors.UseAfterMove());

                    // TODO: class for 'infos' / better way to handle this
                    CTX.Diagnostics.AddInfo(
                        block.MovedNamedValues[arg],
                        $"Value was moved from here");
                }
            }

            // Local declarations; mark for drop
            if(inst.Kind is InstructionKind.Local)
            {
                block.DropAtEnd.Add(DroppableValue.ViaPointer(
                    inst.ValueID.Unwrap()));
            }
            // Stores; drop before store
            else if(inst.Kind is InstructionKind.Store store)
            {
                var toDrop = DroppableValue.ViaPointer(store.Ptr);

                block.DropAtEnd.Remove(toDrop);
                block.DropBeforeInstruction.Add((
                    inst, toDrop));
            }
            // Load; mark for drop
            else if(inst.Kind is InstructionKind.Load load)
            {
                // ERROR here if not a copyable type //
                var toDrop = DroppableValue.ViaDirect(inst.ValueID.Unwrap());
                block.DropAtEnd.Add(toDrop);

                if(!inst.Type.TriviallyCopyable)
                {
                    if(block.Function.VariableMappings.Contains(load.Ptr))
                    {
                        block.MovedNamedValues[load.Ptr] = inst.Span;
                    }
                    else
                    {
                        CTX.Diagnostics.AddError(
                            inst.Span,
                            Errors.MoveOutOfReference());
                    }
                }
            }
        }

        // TODO; inject drop code based on computed values

    }
}