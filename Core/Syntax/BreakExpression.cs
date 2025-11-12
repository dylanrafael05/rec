using Re.C.Definitions;

namespace Re.C.Syntax;

public class BreakStructStatement : BoundSyntax
{
    public record struct Part(Variable Var, int FieldIndex);

    public required Expression Target { get; init; }
    public required Seq<Part> Parts { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Target);
    }
}