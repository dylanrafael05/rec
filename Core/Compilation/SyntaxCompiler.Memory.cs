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
        
    private RecValue CompileTempAddrOf(TempAddressOfExpression context)
    {
        if(context.Inner.HasAddress)
            return CompileAsLHS(context.Inner);

        var ptrtype = context.Type.UnwrapAs<PointerType>();
        var ptr = CTX.Builder.BuildAlloca(ptrtype.Pointee.Compile(CTX));
        var val = Compile(context.Inner).Unwrap();
        CTX.Builder.BuildStore(val, ptr);
        
        return ptr;
    }

    private RecValue CompileDeref(DerefExpression context)
    {
        var inner = Compile(context.Inner).Unwrap();
        return CTX.Builder.BuildLoad2(context.Type.Compile(CTX), inner);
    }

    private RecValue CompileDerefAsLHS(DerefExpression context)
        => Compile(context.Inner);
}