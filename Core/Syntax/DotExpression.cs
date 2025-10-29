namespace Re.C.Syntax;

public class DotExpression : Expression
{
    public required Expression Inner { get; init; }
    public required int FieldIndex { get; init; }
    public override bool HasAddress => Inner.HasAddress;

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Inner);
    }
}
