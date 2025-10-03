namespace Re.C.Syntax;

/// <summary>
/// An enumeration of all the types of binary
/// operators that Re:C supports.
/// </summary>
public enum BinaryOperator
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Modulo,

    CompEq,
    CompNe,
    CompGr,
    CompGEq,
    CompLe,
    CompLEq,


    BitLeft,
    BitRight,
    BitAnd,
    BitOr,
    BitXor,

    LogicAnd,
    LogicOr,
}
