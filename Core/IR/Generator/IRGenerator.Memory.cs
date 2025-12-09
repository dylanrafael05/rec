using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateAddrOf(AddressOfExpression context)
        => GenerateAsLHS(context.Inner);
        
    private ValueRef GenerateTempAddrOf(TempAddressOfExpression context)
    {
        if(context.Inner.HasAddress)
            return GenerateAsLHS(context.Inner);

        var val = Generate(context.Inner);
        return Builder.Build(context, new InstructionKind.Local(val));
    }

    private ValueRef GenerateDeref(DerefExpression context)
    {
        var inner = Generate(context.Inner);
        return Builder.Build(context, new InstructionKind.Load(inner));
    }

    private ValueRef GenerateDerefAsLHS(DerefExpression context)
        => ValueRef.WithSpan(Generate(context.Inner), context.Span);
}