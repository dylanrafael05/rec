namespace Re.C.Syntax;

public class ErrorStatement : BoundSyntax
{
    public override bool IsError => true;
}

public class ErrorExpression : Expression
{
    public override bool IsError => true;
}