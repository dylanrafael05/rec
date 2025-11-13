namespace Re.C.Syntax;

public class FloatLiteral : Expression
{
    public required double Value { get; init; }
}

public class StringLiteral : Expression
{
    public required string Value { get; init; }
}

public class IntLiteral : Expression
{
    public required UInt128 Value { get; init; }
}
