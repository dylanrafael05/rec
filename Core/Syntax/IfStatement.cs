using OneOf;

namespace Re.C.Syntax;

public class IfStatement : BoundSyntax
{
    public required Expression Condition { get; init; }
    public required Block Then { get; init; }
    public required OneOf<IfStatement, Block, Unit> Else { get; init; }
}
