using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateArg(InstructionKind.Argument arg, Instruction inst)
        => Option.Some(CurrentLLVMFunction.GetParam((uint)arg.Index));
}