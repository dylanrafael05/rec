namespace Re.C.Syntax;

public class DerefExpression : Expression
{
    public required Expression Inner { get; init; }
    public override bool HasAddress => true;

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Inner);
    }
}
