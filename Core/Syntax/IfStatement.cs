using OneOf;

namespace Re.C.Syntax;

public class IfStatement : BoundSyntax
{
    public required Expression Condition { get; init; }
    public required Block Then { get; init; }
    public required OneOf<IfStatement, Block, Unit> Else { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Condition);
        visitor.Visit(Then);

        if (Else.IsT0)
        {
            visitor.Visit(Else.AsT0, nameof(Else));
        }
        else if(Else.IsT1)
        {
            visitor.Visit(Else.AsT1, nameof(Else));
        }
    }
}
