using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateArray(ArrayExpression context)
    {
        return Builder.Build(context, new InstructionKind.ArrayLiteral(ArrayConstruction.Direct([..
            from v in context.Values
            select Generate(v)
        ])));
    }

    private ValueID GenerateArrayRepeat(ArrayRepeatExpression context)
    {
        return Builder.Build(context, new InstructionKind.ArrayLiteral(ArrayConstruction.Duplication(
            Generate(context.ValueToRepeat),
            Generate(context.Count)
        )));
    }

    private ValueID GenerateArrayRaw(ArrayRawExpression context)
    {
        return Builder.Build(context, new InstructionKind.ArrayLiteral(ArrayConstruction.Raw(
            Generate(context.Ptr),
            Generate(context.Count)
        )));
    }
}