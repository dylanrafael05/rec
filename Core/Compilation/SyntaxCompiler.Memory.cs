using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

using Type = Re.C.Types.Type;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileAddrOf(AddressOfExpression context)
        => CompileAsLHS(context.Inner);

    private RecValue CompileDeref(DerefExpression context)
    {
        var inner = Compile(context.Inner).Unwrap();
        return CTX.Builder.BuildLoad2(context.Type.Compile(CTX), inner);
    }

    private RecValue CompileDerefAsLHS(DerefExpression context)
        => Compile(context.Inner);
}