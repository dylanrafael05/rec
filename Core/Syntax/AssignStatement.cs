namespace Re.C.Syntax;

public class AssignStatement : BoundSyntax
{
    public required Expression Target { get; init; }
    public required Expression Value { get; init; }
}