using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateArray(ArrayExpression context)
    {
        return Builder.Build(context, new InstructionKind.ArrayLiteral(ArrayConstruction.Direct([..
            from v in context.Values
            select Generate(v)
        ])));
    }

    private ValueRef GenerateArrayRepeat(ArrayRepeatExpression context)
    {
        return Builder.Build(context, new InstructionKind.ArrayLiteral(ArrayConstruction.Duplication(
            Generate(context.ValueToRepeat),
            Generate(context.Count)
        )));
    }

    private ValueRef GenerateArrayRaw(ArrayRawExpression context)
    {
        return Builder.Build(context, new InstructionKind.ArrayLiteral(ArrayConstruction.Raw(
            Generate(context.Ptr),
            Generate(context.Count)
        )));
    }
}