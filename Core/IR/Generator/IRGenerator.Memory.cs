using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateAddrOf(AddressOfExpression context)
        => GenerateAsLHS(context.Inner);
        
    private ValueID GenerateTempAddrOf(TempAddressOfExpression context)
    {
        if(context.Inner.HasAddress)
            return GenerateAsLHS(context.Inner);

        var val = Generate(context.Inner);
        return Builder.BuildInst(context, new InstructionKind.Local(val));
    }

    private ValueID GenerateDeref(DerefExpression context)
    {
        var inner = Generate(context.Inner);
        return Builder.BuildInst(context, new InstructionKind.Load(inner));
    }

    private ValueID GenerateDerefAsLHS(DerefExpression context)
        => Generate(context.Inner);
}