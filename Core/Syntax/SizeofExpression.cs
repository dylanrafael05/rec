using Re.C.Types;

namespace Re.C.Syntax;

public class SizeofExpression : Expression
{
    public required RecType Target { get; init; }
}