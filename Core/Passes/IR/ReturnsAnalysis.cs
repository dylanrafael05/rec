using Re.C.IR;

namespace Re.C.Passes;

public class ReturnsAnalysis(RecContext ctx) : IRPass(ctx)
{
    public override void Perform(IRFunction fn)
    {
        // Propogate calculation; this *should* reach all
        // blocks in a well-formed program
        Visit(fn.EntryBlock);

        // If our last block does not always return,
        // either report an error or insert a return
        if(!fn.FinalBlock.Returns.Unwrap())
        {
            if(!fn.Function.Type.Return.IsNone)
            {
                CTX.Diagnostics.AddError(
                    fn.Function.DefinitionLocation.Unwrap(),
                    Errors.MustReturn());
            }
            else
            {
                var span = SourceSpan.Generated(fn.Function.DefinitionSource);

                Builder.PositionAtEnd(fn.FinalBlock);
                var none = Builder.BuildInst(CTX.BuiltinTypes.None, span,
                    new InstructionKind.NoneLiteral());
                Builder.BuildInst(CTX.BuiltinTypes.None, span, 
                    new InstructionKind.Return(none));
            }
        }
    }

    private void Visit(InstructionBlock block)
    {
        // Exit if we have already computed if this block returns
        if(block.Returns.IsSome(out _))
            return;
            
        // Visit antecedents (to ensure they are calculated if we have
        // 'skipped' blocks during traversal).
        foreach(var antecedent in block.Antecedents)
            Visit(antecedent);

        // Check if all antecedents always return
        var returns = block.Antecedents.Count > 0 && 
            block.Antecedents.All(x => x.Returns.Unwrap());

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
        block.Returns = Option.Some(returns);

        // Visit children to propogate
        foreach(var consequent in block.Consequents)
            Visit(consequent);
    }
}