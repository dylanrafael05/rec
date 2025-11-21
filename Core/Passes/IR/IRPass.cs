using Antlr4.Runtime.Misc;
using Re.C.IR;

namespace Re.C.Passes;

public abstract class IRPass(RecContext ctx) : BasePass(ctx)
{
    private readonly HashSet<InstructionBlock> visitees = [];

    public IRBuilder Builder => CTX.IRBuilder;
    public override bool EnterAsBlocks => true;
    
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        if(context.DefinedFunction.IRFunction.IsSome(out var fn))
        {
            Traverse(fn.EntryBlock);
            Perform(context.DefinedFunction.IRFunction.Unwrap());
        }

        return default;
    }

    /// <summary>
    /// Traverse through the antecedent and consequent blocks
    /// of the provided block, calling 'visit' between.
    /// </summary>
    /// <param name="block"></param>
    private void Traverse(InstructionBlock block)
    {
        if(visitees.Contains(block))
            return;

        visitees.Add(block);

        foreach(var antecedent in block.Antecedents)
            Traverse(antecedent);

        VisitBlock(block);

        foreach(var consequent in block.Consequents)
            Traverse(consequent);
    }

    protected abstract void VisitBlock(InstructionBlock block);

    /// <summary>
    /// The driver method of this analysis pass.
    /// </summary>
    public abstract void Perform(IRFunction function);
}