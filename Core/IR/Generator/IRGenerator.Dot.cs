using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateDot(DotExpression context)
    {
        if(context.Inner.HasAddress)
        {
            var ptr = GenerateDotAsLHS(context);
            return Builder.Build(context, 
                new InstructionKind.Load(ptr));
        }

        var value = Generate(context.Inner);
        return Builder.Build(context, 
            new InstructionKind.FieldCopy(value, context.FieldIndex));
    }

    public ValueID GenerateDotAsLHS(DotExpression context)
    {
        var ptr = GenerateAsLHS(context.Inner);
        return Builder.Build(context, 
            new InstructionKind.FieldPtr(ptr, context.FieldIndex));
    }
}