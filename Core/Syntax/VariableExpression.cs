using Re.C.Definitions;

namespace Re.C.Syntax;

public class VariableExpression : Expression
{
    public required Variable Variable { get; init; }
    public override bool Assignable => true;
}
