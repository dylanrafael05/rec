using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateFloat(InstructionKind.FloatLiteral flt, Instruction inst)
    {
        return Option.Some(LLVMValueRef.CreateConstReal(
            CTX.TypeCompiler.Compile(inst.Type),
            flt.Value));
    }
}