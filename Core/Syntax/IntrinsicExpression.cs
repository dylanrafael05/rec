using Re.C.Definitions;

namespace Re.C.Syntax;

public class IntrinsicExpression : Expression
{
    public required Expression[] Args { get; init; }
    public required Intrinsic Intrinsic { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.VisitMany(Args);
    }
}
