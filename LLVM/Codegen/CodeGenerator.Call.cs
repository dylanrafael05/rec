using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateCall(InstructionKind.Call call, Instruction inst)
    {
        var args = (LLVMValueRef[])[..
            from arg in call.Arguments select ValueOf(arg)
        ];

        var fnValue = ValueOf(call.TargetPtr);
        var fnPtrType = CurrentFunction.InstructionByValue(call.TargetPtr).Type;

        var fnType = fnPtrType
            .UnwrapAs<PointerType>()
            .Pointee
            .UnwrapAs<FunctionType>();

        return Option.Some(
            CTX.Builder.BuildCall2(CTX.TypeCompiler.Compile(fnType), fnValue, args));
    }
}