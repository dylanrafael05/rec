using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateStruct(StructExpression context)
    {
        var fields = (ValueID[])[..
            from f in context.Fields
            select Generate(f)
        ];

        return Builder.Build(context, new InstructionKind.StructLiteral(fields));
    }
}