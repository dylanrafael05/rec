using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateFieldCopy(InstructionKind.FieldCopy fc, Instruction inst)
    {
        return GenerateFieldCopyFromIndex(fc.Value, fc.Index);
    }

    private Option<LLVMValueRef> GenerateFieldCopyFromIndex(ValueID value, int index)
    {
        var lvalue = ValueOf(value);
        return Option.Some(
            CTX.Builder.BuildExtractValue(lvalue, (uint)index));
    }
}