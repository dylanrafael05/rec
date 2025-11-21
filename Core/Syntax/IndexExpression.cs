namespace Re.C.Syntax;

public class IndexExpression : Expression
{
    public required Expression Target { get; init; }
    public required Expression Index { get; init; }

    public override bool HasAddress => true;
    public override bool CanBeAssigned => true;

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Target);
        visitor.Visit(Index);
    }
}