namespace Re.C.Syntax;

public class ReturnStatement : BoundSyntax
{
    public required Expression Value { get; init; }
}