namespace Re.C.Syntax;

public class StructExpression : Expression
{
    /// <summary>
    /// The expressions for each field (Fields[0] corresponds to 
    /// the field Type.Fields[0]).
    /// </summary>
    public required Expression[] Fields { get; init; }

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.VisitMany(Fields);
    }
}