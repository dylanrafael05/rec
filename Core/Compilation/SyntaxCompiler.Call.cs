using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileCall(CallExpression context)
    {
        // TODO: 'unit' typed arguments?
        var args = (LLVMValueRef[])[..
            from arg in context.Args select Compile(arg).Unwrap()
        ];

        var fnValue = Compile(context.Function).Unwrap();
        var fnType = context.Function.Type;

        Assert(fnType is FunctionType);

        return CTX.Builder.BuildCall2(fnType.Compile(CTX), fnValue, args);
    }
}