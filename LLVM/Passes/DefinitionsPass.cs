using Antlr4.Runtime.Misc;

namespace Re.C.LLVM.Passes;

public class DefinitionsPass(LLVMContext ctx) : BaseLLVMPass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        if(context.DefinedFunction.IRFunction.IsSome(out var fn))
            CTX.CodeGenerator.GenerateFunction(fn);

        return default;
    }
}