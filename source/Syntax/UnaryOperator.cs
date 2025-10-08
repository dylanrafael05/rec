namespace Re.C.Syntax;

/// <summary>
/// An enumeration of all the unary operators that Re:C
/// supports.
/// </summary>
public enum UnaryOperator
{
    [EnumRepr("+")] Posit,
    [EnumRepr("-")] Negate,
    [EnumRepr("~")] BitNot,
    [EnumRepr("not")] LogicNot,
}
