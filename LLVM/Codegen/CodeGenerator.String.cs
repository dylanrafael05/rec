using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateString(InstructionKind.StringLiteral str, Instruction inst)
    {
        return Option.Some(GenerateArrayFromParts(
            inst.Type.UnwrapAs<ArrayType>(),
            CTX.Builder.BuildGlobalString(str.Value),
            USizeLiteral(str.Value.Length)
        ));
    }
}