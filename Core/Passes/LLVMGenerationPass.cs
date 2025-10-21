using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Passes;

public class LLVMGenerationPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        CTX.SyntaxCompiler.CompileFunction(context.DefinedFunction.UnwrapNull());
        return default;
    }
}