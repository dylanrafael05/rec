using Re.C.Definitions;
using Re.C.Vocabulary;

namespace Re.C.Syntax;

public class BoundSyntax
{
    public required SourceSpan Span { get; init; }
}

public class ModSyntax : BoundSyntax
{
    public required Scope Scope { get; init; }
}

public class BoundExpression : BoundSyntax
{
    public required Type? Type { get; init; }
}

public enum BinaryOperator
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Modulo,

    CompEq,
    CompNe,
    CompGr,
    CompGEq,
    CompLe,
    CompLEq,


    BitLeft,
    BitRight,
    BitAnd,
    BitOr,
    BitXor,

    LogicAnd,
    LogicOr,
}

public class BinaryExpression : BoundExpression
{
    public required BoundExpression LHS { get; init; }
    public required BoundExpression RHS { get; init; }
    public required BinaryOperator Operator { get; init; }
}

public enum UnaryOperator
{
    Negate,
    BitNot,
    LogicNot,
}

public class UnaryExpression : BoundExpression
{
    public required BoundExpression Operand { get; init; }
    public required UnaryOperator Operator { get; init; }
}