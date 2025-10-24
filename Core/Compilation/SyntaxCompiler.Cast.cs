using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileCast(CastExpression context)
    {
        var value = Compile(context.Value).Unwrap();

        var t1 = context.Value.Type;
        var t2 = context.Type;

        var b = CTX.Builder;

        var l1 = t1.Compile(CTX);
        var l2 = t2.Compile(CTX);

        var s1 = CTX.TargetData.StoreSizeOfType(l1);
        var s2 = CTX.TargetData.StoreSizeOfType(l2);

        // No-op casts //
        if(t1 == t2)
            return value;

        if(t1.IsInteger && t2.IsInteger && s1 == s2)
            return value;

        if(t1 is PointerType && t2 is PointerType)
            return value;

        // Meaningful casts //
        return (t1, t2) switch
        {
            ({ IsInteger: true }, { IsInteger: true, IsSigned: true }) when s1 < s2
                => b.BuildSExt(value, l2),
            ({ IsInteger: true }, { IsInteger: true, IsSigned: false }) when s1 < s2
                => b.BuildZExt(value, l2),
            
            ({ IsInteger: true }, { IsInteger: true }) when s1 > s2
                => b.BuildTrunc(value, l2),

            ({ IsInteger: true, IsSigned: true }, { IsFloat: true })
                => b.BuildSIToFP(value, l2),
            ({ IsInteger: true, IsSigned: false }, { IsFloat: true })
                => b.BuildUIToFP(value, l2),
                
            ({ IsFloat: true }, { IsInteger: true, IsSigned: true })
                => b.BuildFPToSI(value, l2),
            ({ IsFloat: true }, { IsInteger: true, IsSigned: false })
                => b.BuildFPToUI(value, l2),
                
            ({ IsFloat: true }, { IsFloat: true }) when s1 < s2
                => b.BuildFPExt(value, l2),
            ({ IsFloat: true }, { IsFloat: true }) when s1 > s2
                => b.BuildFPTrunc(value, l2),

            _ => throw Unimplemented  
        };
    }
}