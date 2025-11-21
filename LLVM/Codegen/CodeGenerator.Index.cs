using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateIndex(InstructionKind.IndexAddress index, Instruction inst)
    {
        return Option.Some(CTX.Builder.BuildGEP2(
            CTX.TypeCompiler.Compile(inst.Type.Deref.Unwrap()),
            CTX.Builder.BuildExtractValue(ValueOf(index.Array), TypeCompiler.ArrayPtrIndex),
            [ValueOf(index.Index)]));
    }
}