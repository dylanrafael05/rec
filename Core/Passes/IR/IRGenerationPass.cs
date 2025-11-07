using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Syntax;
using Re.C.Visitor;

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