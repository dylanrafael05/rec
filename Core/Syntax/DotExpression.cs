namespace Re.C.Syntax;

public class DotExpression : Expression
{
    public required Expression Inner { get; init; }
    public required DotField Field { get; init; }
    public override bool HasAddress => Inner.HasAddress && Field.MatchesStruct;
    public override bool CanBeAssigned => Inner.CanBeAssigned && Field.MatchesStruct;

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Inner);
    }
}
