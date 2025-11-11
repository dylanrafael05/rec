using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateFn(InstructionKind.FunctionLiteral fn, Instruction inst)
    {
        return Option.Some(LLVMFunctions[fn.Function.IRFunction.Unwrap()]);
    }
}