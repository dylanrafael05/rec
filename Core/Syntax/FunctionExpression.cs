using Re.C.Definitions;

namespace Re.C.Syntax;

public class FunctionExpression : Expression
{
    public required Function Function { get; init; }
    public override bool HasAddress => true;

    // TODO: add support for addressable but not assignable expressions
}