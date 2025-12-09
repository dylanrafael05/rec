using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueRef GenerateStruct(StructExpression context)
    {
        var fields = (ValueRef[])[..
            from f in context.Fields
            select Generate(f)
        ];

        return Builder.Build(context, new InstructionKind.StructLiteral(fields));
    }
}