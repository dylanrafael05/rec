using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.IR;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Passes;

public abstract class IRPass(RecContext ctx) : BasePass(ctx)
{
    public IRBuilder Builder => CTX.IRBuilder;
    public override bool EnterAsBlocks => true;
    
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        Perform(context.DefinedFunction.IRFunction.Unwrap());
        return default;
    }

    /// <summary>
    /// The driver method of this analysis pass.
    /// </summary>
    public abstract void Perform(IRFunction function);
}