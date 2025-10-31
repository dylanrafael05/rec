namespace Re.C.Syntax;

public class ReturnStatement : BoundSyntax
{
    public required Option<Expression> Value { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        if(Value.IsSome(out var value))
            visitor.Visit(value);
    }
}