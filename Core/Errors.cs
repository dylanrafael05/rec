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
    /// <summary>
    /// The provided name is not defined in the *current* scope.
    /// </summary>
    public static string UndefinedInCurrentScope(Identifier name)
        => $"Could not find a definition of '{name}' in current context";
    /// <summary>
    /// The provided name is not defined in the *provided* scope.
    /// </summary>
    public static string UndefinedInGivenScope(Identifier name, IDefinition scope)
        => $"Could not find a definition of '{name}' in '{scope.FullName}'";

    /// <summary>
    /// The provided name is ambiguous; it can refer to one of many distinct
    /// and equally relevant definitions.
    /// </summary>
    public static string Ambiguous(Identifier name, IEnumerable<IDefinition> defs)
        => $"Ambiguous reference to '{name}' in current context; could be {string.Join(" or ", from d in defs select d.FullName)}";
    
    /// <summary>
    /// The provided type has no field named 'ident'.
    /// </summary>
    public static string UndefinedField(RecType operand, Identifier ident)
        => $"No such field {ident} on type {operand}";
    
    /// <summary>
    /// It is illegal to use a the :: operator since its target is not a scope.
    /// </summary>
    public static string InvalidScopeResolutionTarget()
        => $"Cannot use '::' here; target is not a scope";

    /// <summary>
    /// Attempt to define a duplicably-named item with the provided name.
    /// </summary>
    public static string Redefinition(Identifier name, Scope scope)
        => $"Redefinition of '{name}' in '{scope}'";

    /// <summary>
    /// A non-external function opts not to define a body.
    /// </summary>
    public static string NoBodyForNonExtern(Identifier name)
        => $"Non-external function '{name}' must define a body";

    /// <summary>
    /// An external function opts to define a body.
    /// </summary>
    public static string BodyForExtern(Identifier name)
        => $"External function '{name}' cannot define a body";

    /// <summary>
    /// A value-returning function must have a return statement.
    /// </summary>
    public static string MustReturn()
        => $"Function with non-none return type must always return";

    /// <summary>
    /// A value is used after it is moved from.
    /// </summary>
    public static string UseAfterMove()
        => $"Use of a non-copyable value after being moved";

    /// <summary>
    /// A value is moved out of a reference.
    /// </summary>
    public static string MoveOutOfReference()
        => $"Cannot move a non-copyable type out of a reference";
        
    /// <summary>
    /// The provided type cannot be used as the target of an
    /// as block.
    /// </summary>
    public static string InvalidAsBlockTarget(RecType type)
        => $"Cannot create an 'as' module for non-named type {type}";
    /// <summary>
    /// An anonymous as block (intrinsic as block) was defined in
    /// a file different from its associated type.
    /// </summary>
    public static string UnnamedAsBlockInDifferentFile()
        => $"Unnamed 'as' modules must be placed in the same file as the type they are associated with";

    /// <summary>
    /// The provided escape sequence is unrecognized.
    /// </summary>
    public static string UnknownEscapeSequence(string escape)
        => $"Unrecognized escape sequence '{escape}'";

    public static string ReferenceToNonValueDefinition(IDefinition def)
        => $"Use of non-value {def.DefinitionKind} as a value";

    public static string TypeMismatch(RecType expected, RecType real)
        => $"Expected a value of type {expected} but got {real}";
    public static string ArrayLitTypeMismatch(RecType expected, RecType real)
        => $"Expected a value of type {expected} to match first element of array, but got {real}";
    public static string ArrayRepNonTrivial(RecType real)
        => $"Cannot use an array repetition statement for non-trivially copy element type {real}";
    public static string ArrayPtrNotPtr(RecType real)
        => $"Array pointer type must be pointer, got {real}";
    public static string StructFieldTypeMismatch(RecType structType, Identifier ident, RecType fieldType, RecType realType)
        => $"Incompatible field type for {structType}.{ident}, expected {fieldType} but got {realType}";
    public static string StructMissingFields(RecType structType, IReadOnlyList<Identifier> missing)
        => $"Incomplete construction of {structType}; missing {string.Join(", ", missing)}";
    // TODO: handle duplicate field references in struct construction
    public static string BreakDuplicateStructField(Identifier field)
        => $"Field {field} has already been used in this 'break'";
    
    
    public static string InvalidAssignmentTarget()
        => $"Cannot assign to this expression";
    public static string InvalidUninitializedAssignmentTarget()
        => $"Cannot uninitialized assign to this expression";

    public static string MathOnNonArithmeticType(RecType type)
        => $"Cannot perform arithmetic on non-arithmetic type {type}";
    public static string InvalidBinaryTypes(BinaryOperator op, RecType lhs, RecType rhs)
        => $"Binary operator {BinaryOperator.GetRepr(op)} does not accept operands of {lhs} and {rhs}";
    public static string InvalidUnaryType(UnaryOperator op, RecType operand)
        => $"Unary operator {UnaryOperator.GetRepr(op)} does not accept operand of type {operand}";
    public static string InvalidIndexExprTarget(RecType target)
        => $"Cannot index a value of type {target}";
    public static string InvalidIndexExprIndex(RecType expected, RecType target)
        => $"Cannot use a value of type {target} as an index (use {expected} instead)";
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

    public static string InvalidType(IDefinition definition)
        => $"Attempt to use {definition.DefinitionKind} as type";
    public static string BadTypeInstantiationBase(IDefinition definition)
        => $"Attempt to use {definition.DefinitionKind} {definition.FullName} as base of type instantiation";
    public static string InvalidNumberOfTypeInstantiationArgs(StructTemplate template, int count)
        => $"Cannot instantiate {template} with {count} type arguments, expected {template.TypeArguments.Length}";
}