using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateStore(InstructionKind.Store store, Instruction inst)
    {
        CTX.Builder.BuildStore(ValueOf(store.Value), ValueOf(store.Ptr));
        return Option.None;
    }
}