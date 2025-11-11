using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateString(InstructionKind.StringLiteral str, Instruction inst)
    {
        return Option.Some(
            CTX.Builder.BuildGlobalString(str.Value));
    }
}