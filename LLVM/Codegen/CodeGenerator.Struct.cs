using LLVMSharp.Interop;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateStruct(InstructionKind.StructLiteral str, Instruction inst)
    {
        var fields = (LLVMValueRef[])[..
            from f in str.Fields
            select ValueOf(f)
        ];

        var stype = CTX.TypeCompiler.Compile(inst.Type);
        var ptr = CTX.Builder.BuildAlloca(stype);

        for(var i = 0; i < fields.Length; i++)
        {
            var eptr = CTX.Builder.BuildStructGEP2(stype, ptr, (uint)i);
            CTX.Builder.BuildStore(fields[i], eptr);
        }

        return Option.Some(CTX.Builder.BuildLoad2(stype, ptr));
    }
}