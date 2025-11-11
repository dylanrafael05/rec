using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateGoto(InstructionKind.Goto gt, Instruction inst)
    {
        CTX.Builder.BuildBr(BlockOf(gt.Target));

        return Option.None;
    }
}