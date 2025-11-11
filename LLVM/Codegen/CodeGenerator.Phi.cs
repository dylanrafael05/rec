using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GeneratePhi(InstructionKind.Phi phi, Instruction inst)
    {
        var lphi = CTX.Builder.BuildPhi(CTX.TypeCompiler.Compile(inst.Type));

        foreach(var incoming in phi.Incoming)
        {
            lphi.AddIncoming(
                [ValueOf(incoming.Value)], [BlockOf(incoming.Key)], 1);
        }

        return Option.Some(lphi);
    }
}