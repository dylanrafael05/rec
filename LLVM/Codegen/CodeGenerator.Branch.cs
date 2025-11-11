using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateBranch(InstructionKind.Branch br, Instruction inst)
    {
        CTX.Builder.BuildCondBr(
            ValueOf(br.Cond), BlockOf(br.WhenTrue), BlockOf(br.WhenFalse));

        return Option.None;
    }
}