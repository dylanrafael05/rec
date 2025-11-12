using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateReturn(InstructionKind.Return ret, Instruction inst)
    {
        if(CurrentFunction.InstructionByValue(ret.Value).Type.IsNone)
        {
            CTX.Builder.BuildRetVoid();
        }
        else
        {
            CTX.Builder.BuildRet(ValueOf(ret.Value));
        }

        return Option.None;
    }
}