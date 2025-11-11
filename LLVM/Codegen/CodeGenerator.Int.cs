using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateInt(InstructionKind.IntLiteral intl, Instruction inst)
    {
        return Option.Some(LLVMValueRef.CreateConstIntOfArbitraryPrecision(
            CTX.TypeCompiler.Compile(inst.Type),
            unchecked([(ulong)intl.Value, (ulong)(intl.Value >> (128 / 2))])));
    }
}