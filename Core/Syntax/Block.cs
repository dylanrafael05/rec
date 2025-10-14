using Re.C.Definitions;
using Re.C.Visitor;

namespace Re.C.Syntax;

public class Block : BoundSyntax
{
    public required BoundSyntax[] Syntax { get; init; }
    public required Scope Scope { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.VisitMany(Syntax);
    }
}
