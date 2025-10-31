namespace Re.C.Syntax;

public class TempAddressOfExpression : Expression
{
    public required Expression Inner { get; init; }
    
    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Inner);
    }
}