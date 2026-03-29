using Re.C.Definitions;

namespace Re.C.Syntax;

public class EnumExpression : Expression
{
    public required EnumMember Member { get; init; }
}
