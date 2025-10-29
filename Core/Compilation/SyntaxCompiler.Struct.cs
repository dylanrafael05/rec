using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public RecValue CompileStruct(StructExpression context)
    {
        var fields = (LLVMValueRef[])[..
            from f in context.Fields
            select Compile(f).Unwrap()
        ];

        var stype = context.Type.Compile(CTX);
        var ptr = CTX.Builder.BuildAlloca(stype);

        for(var i = 0; i < fields.Length; i++)
        {
            var eptr = CTX.Builder.BuildStructGEP2(stype, ptr, (uint)i);
            CTX.Builder.BuildStore(fields[i], eptr);
        }

        return CTX.Builder.BuildLoad2(stype, ptr);
    }
}