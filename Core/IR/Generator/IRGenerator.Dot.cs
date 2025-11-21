using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateDot(DotExpression context)
    {
        if(context.Field.IsStruct(out var index))
        {
            if(context.Inner.HasAddress)
            {
                var ptr = GenerateDotAsLHS(context);
                return Builder.Build(context, 
                    new InstructionKind.Load(ptr));
            }

            var value = Generate(context.Inner);
            return Builder.Build(context, 
                new InstructionKind.FieldCopy(value, index));
        }
        else if(context.Field.IsArraySize)
        {
            var value = Generate(context.Inner);
            return Builder.Build(context, 
                new InstructionKind.ArraySize(value));
        }
        else if(context.Field.IsArrayPtr)
        {
            var value = Generate(context.Inner);
            return Builder.Build(context, 
                new InstructionKind.ArrayPtr(value));
        }

        throw Unreachable;
    }

    public ValueID GenerateDotAsLHS(DotExpression context)
    {
        var ptr = GenerateAsLHS(context.Inner);
        return Builder.Build(context, 
            new InstructionKind.FieldPtr(ptr, context.Field.UnwrapAsStruct().Index));
    }
}