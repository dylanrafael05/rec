using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateLoad(InstructionKind.Load load, Instruction inst)
    {
        return Option.Some(CTX.Builder.BuildLoad2(
            CTX.TypeCompiler.Compile(inst.Type),
            ValueOf(load.Ptr)));
    }
}