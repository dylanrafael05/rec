using Re.C.Visitor;

namespace Re.C.Syntax;

public class AssignStatement : BoundSyntax
{
    public required Expression Target { get; init; }
    public required Expression Value { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Target);
        visitor.Visit(Value);
    }
}