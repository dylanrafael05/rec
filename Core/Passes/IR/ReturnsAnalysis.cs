using Re.C.IR;

namespace Re.C.Passes;

public class ReturnsAnalysis(RecContext ctx) : IRPass(ctx)
{
    public override void Perform(IRFunction fn)
    {
        // If our last block does not always return,
        // either report an error or insert a return
        if(!fn.FinalBlock.DefinitelyReturns)
        {
            if(!fn.Function.Type.Return.IsNone)
            {
                CTX.Diagnostics.AddError(
                    fn.Function.DefinitionLocation,
                    Errors.MustReturn());
            }
            else
            {
                var span = SourceSpan.Generated(fn.Function.DefinitionSource);

                Builder.PositionAtEnd(fn.FinalBlock);
                var none = Builder.Build(CTX.BuiltinTypes.None, span,
                    new InstructionKind.NoneLiteral());
                Builder.Build(CTX.BuiltinTypes.None, span, 
                    new InstructionKind.Return(none));
            }
        }
    }

    protected override void VisitBlock(InstructionBlock block)
    {
        // Check if all antecedents always return
        var returns = block.Antecedents.Count > 0 && 
            block.Antecedents.All(x => x.DefinitelyReturns);

        // If we have a 'return' instruction, we always return
        foreach(var inst in block.Instructions)
        {
            if(inst.Kind is InstructionKind.Return)
            {
                returns = true;
                break;
            }
        }

        // Update our state
        block.DefinitelyReturns = returns;
    }
}