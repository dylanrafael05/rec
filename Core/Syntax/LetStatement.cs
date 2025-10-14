using Re.C.Definitions;

namespace Re.C.Syntax;

public class LetStatement : BoundSyntax
{
    public required Variable Variable { get; init; }
    public required Expression TargetValue { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(TargetValue);
    }
}
