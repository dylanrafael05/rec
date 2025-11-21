namespace Re.C.Syntax;

public class ArrayExpression : Expression
{
    public required Expression[] Values { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.VisitMany(Values);
    }
}