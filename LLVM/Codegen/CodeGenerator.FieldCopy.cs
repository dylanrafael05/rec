using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateFieldCopy(InstructionKind.FieldCopy fc, Instruction inst)
    {
        var value = ValueOf(fc.Value);
        return Option.Some(
            CTX.Builder.BuildExtractValue(value, (uint)fc.Index));
    }
}