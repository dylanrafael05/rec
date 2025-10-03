namespace Re.C.Syntax;

public class WhileStatement : BoundSyntax
{
    public required Expression Condition { get; init; }
    public required Block Then { get; init; }
}