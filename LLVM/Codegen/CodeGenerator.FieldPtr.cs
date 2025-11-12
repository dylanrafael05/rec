using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateFieldPtr(InstructionKind.FieldPtr fc, Instruction inst)
    {
        var val = ValueOf(fc.Ptr);
        var ty = CurrentFunction.InstructionByValue(fc.Ptr).Type;
        return Option.Some(CTX.Builder.BuildStructGEP2(
            CTX.TypeCompiler.Compile(ty.UnwrapAs<PointerType>().Pointee), 
            val, 
            (uint)fc.Index));
    }
}