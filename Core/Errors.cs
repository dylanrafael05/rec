using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C;

/// <summary>
/// A helper class which provides a human-readable
/// interface for generating error messages.
/// </summary>
public static class Errors
{
    public static string UndefinedInCurrentScope(Identifier name)
        => $"Could not find a definition of '{name}' in current context";
    public static string UndefinedInGivenScope(Identifier name, IDefinition scope)
        => $"Could not find a definition of '{name}' in '{scope}'";
    public static string InvalidScopeResolutionTarget()
        => $"Cannot use '.' here; target is not a scope";
    public static string Redefinition(Identifier name, Scope scope)
        => $"Redefinition of '{name}' in '{scope}'";

    public static string NoBodyForNonExtern(Identifier name)
        => $"Non-external function '{name}' must define a body";
    public static string BodyForExtern(Identifier name)
        => $"External function '{name}' cannot define a body";

    public static string UnknownEscapeSequence(string escape)
        => $"Unrecognized escape sequence '{escape}'";

    public static string TypeMismatch(Types.Type expected, Types.Type real)
        => $"Expected a value of type {expected} but got {real}";
    public static string InvalidAssignmentTarget()
        => $"Cannot assign to this expression";

    public static string MathOnNonArithmeticType(Types.Type type)
        => $"Cannot perform arithmetic on non-arithmetic type {type}";
    public static string InvalidBinaryTypes(BinaryOperator op, Types.Type lhs, Types.Type rhs)
        => $"Binary operator {BinaryOperator.GetRepr(op)} does not accept operands of {lhs} and {rhs}";
    public static string InvalidUnaryType(UnaryOperator op, Types.Type operand)
        => $"Unary operator {UnaryOperator.GetRepr(op)} does not accept operand of type {operand}";
    public static string InvalidConditionType(Types.Type condition)
        => $"Control flow conditions must be booleans, not {condition}";
    public static string InvalidCast(Types.Type to, Types.Type from)
        => $"Cannot cast from value of type {from} to {to}";
    public static string InvalidDereference(Types.Type operand)
        => $"Cannot dereference value of type {operand}";
    public static string InvalidAddressOf()
        => $"Cannot take address of this expression";
    public static string InvalidMethod(IDefinition? def)
        => $"Invalid method {def}";
    
    public static string CallToNonFunctionType(Types.Type type)
        => $"Cannot call a non-function value of type {type}";
    public static string InvalidCallToFunction(FunctionType fn, IEnumerable<Types.Type> types)
        => $"Invalid call; expected ({string.Join(", ", fn.Parameters)}), got ({string.Join(", ", types)})";
}