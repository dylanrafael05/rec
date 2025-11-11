using Antlr4.Runtime.Misc;

namespace Re.C.LLVM.Passes;

public class DeclarationsPass(LLVMContext ctx) : BaseLLVMPass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        CTX.CodeGenerator.DefineFunction(
            context.DefinedFunction.IRFunction.Unwrap());

        return default;
    }
}