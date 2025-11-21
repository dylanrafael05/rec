namespace Re.C.Syntax;

public class ArrayRawExpression : Expression
{
    public required Expression Ptr { get; init; }
    public required Expression Count { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Ptr);
        visitor.Visit(Count);
    }
}
