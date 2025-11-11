namespace Re.C.Syntax;

public class CallExpression : Expression
{
    public required Expression Function { get; init; }
    public required Expression[] Args { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Function);
        visitor.VisitMany(Args);
    }
}