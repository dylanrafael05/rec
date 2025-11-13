using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateSizeof(InstructionKind.Sizeof size, Instruction inst)
    {
        return Option.Some(LLVMValueRef.CreateConstInt(
            CTX.TypeCompiler.Compile(inst.Type),
            CTX.TargetData.StoreSizeOfType(CTX.TypeCompiler.Compile(size.Type))
        ));
    }
}