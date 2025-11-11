using Antlr4.Runtime.Misc;

namespace Re.C.LLVM.Passes;

public class DefinitionsPass(LLVMContext ctx) : BaseLLVMPass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        CTX.CodeGenerator.GenerateFunction(
            context.DefinedFunction.IRFunction.Unwrap());

        return default;
    }
}