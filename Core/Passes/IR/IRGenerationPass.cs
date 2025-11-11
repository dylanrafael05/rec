using Antlr4.Runtime.Misc;

namespace Re.C.Passes;

public class IRGenerationPass(RecContext ctx) : BasePass(ctx)
{
    public override bool EnterAsBlocks => true;
    
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        CTX.IRGenerator.RealizeFunction(context.DefinedFunction.UnwrapNull());
        return default;
    }
}