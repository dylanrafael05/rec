using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateNone(InstructionKind.NoneLiteral local, Instruction inst)
    {
        return Option.Some(NoneLiteral);
    }
}