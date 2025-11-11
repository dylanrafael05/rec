using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateFieldPtr(InstructionKind.FieldPtr fc, Instruction inst)
    {
        var val = ValueOf(fc.Ptr);
        var ty = CurrentFunction.InstructionByValue(fc.Ptr).Type;
        return Option.Some(CTX.Builder.BuildStructGEP2(
            CTX.TypeCompiler.Compile(ty), 
            val, 
            (uint)fc.Index));
    }
}