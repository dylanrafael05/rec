using Re.C.Visitor;

namespace Re.C.Syntax;

public class CastExpression : Expression
{
    public required Expression Value { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Value);
    }
}