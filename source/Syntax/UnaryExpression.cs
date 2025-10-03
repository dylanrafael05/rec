namespace Re.C.Syntax;

/// <summary>
/// A bound expression of the form "<op> A"
/// </summary>
public class UnaryExpression : Expression
{
    public required Expression Operand { get; init; }
    public required UnaryOperator Operator { get; init; }
}
