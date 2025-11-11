using Re.C.Passes;

namespace Re.C.LLVM.Passes;

public abstract class BaseLLVMPass(LLVMContext ctx) : BasePass(ctx.ReC)
{
    public new LLVMContext CTX { get; } = ctx;
    public override bool EnterAsBlocks => true;
}