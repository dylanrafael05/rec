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
        => $"Could not find a definition of '{name}' in '{scope.FullName}'";
    public static string AmbiguousIdentifier(Identifier name, IEnumerable<IDefinition> defs)
        => $"Ambiguous reference to '{name}' in current context; could be {string.Join(" or ", from d in defs select d.FullName)}";
    public static string UndefinedStructField(Types.Type operand, Identifier ident)
        => $"No such field {ident} on type {operand}";
    public static string InvalidScopeResolutionTarget()
        => $"Cannot use '.' here; target is not a scope";
    public static string Redefinition(Identifier name, Scope scope)
        => $"Redefinition of '{name}' in '{scope}'";

    public static string NoBodyForNonExtern(Identifier name)
        => $"Non-external function '{name}' must define a body";
    public static string BodyForExtern(Identifier name)
        => $"External function '{name}' cannot define a body";
    public static string MustReturn()
        => $"Function with non-none return type must always return";
    public static string UseAfterMove()
        => $"Use of a non-copyable value after being moved";
    public static string MoveOutOfReference()
        => $"Cannot move a non-copyable type out of a reference";
        
    public static string InvalidAsBlockTarget(Types.Type type)
        => $"Cannot create an 'as' block for non-named type {type}";
    public static string UnnamedAsBlockInDifferentFile()
        => $"Unnamed 'as' blocks must be placed in the same file as the type they are associated with";

    public static string UnknownEscapeSequence(string escape)
        => $"Unrecognized escape sequence '{escape}'";

    public static string TypeMismatch(Types.Type expected, Types.Type real)
        => $"Expected a value of type {expected} but got {real}";
    public static string StructFieldTypeMismatch(Types.Type structType, Identifier ident, Types.Type fieldType, Types.Type realType)
        => $"Incompatible field type for {structType}.{ident}, expected {fieldType} but got {realType}";
    public static string StructMissingFields(Types.Type structType, IReadOnlyList<Identifier> missing)
        => $"Incomplete construction of {structType}; missing {string.Join(", ", missing)}";
    
    
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
    public static string InvalidDotTarget(Types.Type operand)
        => $"Cannot access fields of non-struct type {operand}";
    public static string InvalidStructExprTarget(Types.Type operand)
        => $"Cannot construct non-struct type {operand}";
    public static string InvalidMethod(IDefinition? def)
        => $"Invalid method {def}";
    
    public static string CallToNonFunctionType(Types.Type type)
        => $"Cannot call a non-function value of type {type}";
    public static string InvalidCallToFunction(FunctionType fn, IEnumerable<Types.Type> types)
        => $"Invalid call; expected ({string.Join(", ", fn.Parameters)}), got ({string.Join(", ", types)})";
}