using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateLocal(InstructionKind.Local local, Instruction inst)
    {
        var type = CTX.TypeCompiler.Compile(CurrentFunction.InstructionByValue(local.Value).Type);
        var alloc = CTX.Builder.BuildAlloca(type);

        CTX.Builder.BuildStore(ValueOf(local.Value), alloc);

        return Option.Some(alloc);
    }
}