namespace Re.C.Syntax;


/// <summary>
/// An enumeration of all the types of binary
/// operators that Re:C supports.
/// </summary>
public enum BinaryOperator
{
    [EnumRepr("+")] Add,
    [EnumRepr("-")] Subtract,
    [EnumRepr("*")] Multiply,
    [EnumRepr("/")] Divide,
    [EnumRepr("%")] Modulo,

    [EnumRepr("==")] CompEq,
    [EnumRepr("!=")] CompNe,
    [EnumRepr(">")] CompGr,
    [EnumRepr(">=")] CompGEq,
    [EnumRepr("<")] CompLe,
    [EnumRepr("<=")] CompLEq,

    [EnumRepr("<<")] BitLeft,
    [EnumRepr(">>")] BitRight,
    [EnumRepr("&")] BitAnd,
    [EnumRepr("|")] BitOr,
    [EnumRepr("^")] BitXor,

    [EnumRepr("and")] LogicAnd,
    [EnumRepr("or")] LogicOr,
}
