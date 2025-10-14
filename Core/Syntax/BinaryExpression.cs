namespace Re.C.Syntax;

/// <summary>
/// A bound expression of the form "A <op> B".
/// </summary>
public class BinaryExpression : Expression
{
    public required Expression LHS { get; init; }
    public required Expression RHS { get; init; }
    public required BinaryOperator Operator { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(LHS);
        visitor.Visit(RHS);
    }
}
