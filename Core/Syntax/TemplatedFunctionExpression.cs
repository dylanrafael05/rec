using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax;

public class TemplatedFunctionExpression : Expression
{
    public required Function Function { get; init; }
    public required Seq<RecType> Arguments { get; init; }
    public override bool HasAddress => true;
}