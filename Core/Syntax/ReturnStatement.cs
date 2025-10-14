namespace Re.C.Syntax;

public class ReturnStatement : BoundSyntax
{
    public required Expression Value { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Value);
    }
}