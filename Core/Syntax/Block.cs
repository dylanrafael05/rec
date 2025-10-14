using Re.C.Definitions;

namespace Re.C.Syntax;

public class Block : BoundSyntax
{
    public required BoundSyntax[] Syntax { get; init; }
    public required Scope Scope { get; init; }
}
