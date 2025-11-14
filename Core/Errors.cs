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
    public static string UndefinedStructField(RecType operand, Identifier ident)
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
        
    public static string InvalidAsBlockTarget(RecType type)
        => $"Cannot create an 'as' block for non-named type {type}";
    public static string UnnamedAsBlockInDifferentFile()
        => $"Unnamed 'as' blocks must be placed in the same file as the type they are associated with";

    public static string UnknownEscapeSequence(string escape)
        => $"Unrecognized escape sequence '{escape}'";

    public static string TypeMismatch(RecType expected, RecType real)
        => $"Expected a value of type {expected} but got {real}";
    public static string StructFieldTypeMismatch(RecType structType, Identifier ident, RecType fieldType, RecType realType)
        => $"Incompatible field type for {structType}.{ident}, expected {fieldType} but got {realType}";
    public static string StructMissingFields(RecType structType, IReadOnlyList<Identifier> missing)
        => $"Incomplete construction of {structType}; missing {string.Join(", ", missing)}";
    // TODO: handle duplicate field references in struct construction
    public static string BreakDuplicateStructField(Identifier field)
        => $"Field {field} has already been used in this 'break'";
    
    
    public static string InvalidAssignmentTarget()
        => $"Cannot assign to this expression";

    public static string MathOnNonArithmeticType(RecType type)
        => $"Cannot perform arithmetic on non-arithmetic type {type}";
    public static string InvalidBinaryTypes(BinaryOperator op, RecType lhs, RecType rhs)
        => $"Binary operator {BinaryOperator.GetRepr(op)} does not accept operands of {lhs} and {rhs}";
    public static string InvalidUnaryType(UnaryOperator op, RecType operand)
        => $"Unary operator {UnaryOperator.GetRepr(op)} does not accept operand of type {operand}";
    public static string InvalidConditionType(RecType condition)
        => $"Control flow conditions must be booleans, not {condition}";
    public static string InvalidCast(RecType to, RecType from)
        => $"Cannot cast from value of type {from} to {to}";
    public static string InvalidDereference(RecType operand)
        => $"Cannot dereference value of type {operand}";
    public static string InvalidAddressOf()
        => $"Cannot take address of this expression";
    public static string InvalidDotTarget(RecType operand)
        => $"Cannot access fields of non-struct type {operand}";
    public static string InvalidStructExprTarget(RecType operand)
        => $"Cannot construct non-struct type {operand}";
    public static string InvalidMethod(IDefinition? def)
        => $"Invalid method {def}";
    public static string InvalidBreak(RecType target)
        => $"Cannot 'break' from non-struct type {target}";
    
    public static string SizeofUnsizedType(RecType target)
        => $"Cannot take the size of a non-sized type {target}";
    
    public static string CallToNonFunctionType(RecType type)
        => $"Cannot call a non-function value of type {type}";
    public static string InvalidCallToFunction(FunctionType fn, IEnumerable<RecType> types)
        => $"Invalid call; expected ({string.Join(", ", fn.Parameters)}), got ({string.Join(", ", types)})";
    public static string UnsafeOperation()
        => $"Attempt to perform unsafe operation in safe context";

    public static string UnknownIntrinsic(string text)
        => $"Unknown intrinsic '{text}'";
    public static string BadIntrinsicTypes(string text, RecType[] types)
        => $"Bad call to intrinsic '{text}' with arguments {string.Join(", ", types)}";
}