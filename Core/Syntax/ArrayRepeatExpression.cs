namespace Re.C.Syntax;

public class ArrayRepeatExpression : Expression
{
    public required Expression ValueToRepeat { get; init; }
    public required Expression Count { get; init; }
    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(ValueToRepeat);
        visitor.Visit(Count);
    }
}
