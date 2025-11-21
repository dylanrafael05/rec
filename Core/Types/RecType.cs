using OneOf.Types;
using Re.C.Visitor;

namespace Re.C.Types;

public abstract class RecType : IEquatable<RecType>, IVisitable
{
    public override string ToString()
        => FullName;

    [FieldOption(PrintLevel.Hidden)] 
    public abstract string Name { get; }
    public abstract string FullName { get; }

    /// <summary>
    /// Return if this type is the builtin 'bool' type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsBool => false;

    /// <summary>
    /// Return if this type is a builtin signed integer type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsSigned => false;
    /// <summary>
    /// Return if this type is a builtin integer type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsInteger => false;
    /// <summary>
    /// Return the minimum possible bit-depth of the maximum
    /// value storage in this integer type, or none if this
    /// is not an integer type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual Option<int> MinIntegerDepth => Option.None;

    /// <summary>
    /// Return if this type is a builtin floating point type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsFloat => false;

    /// <summary>
    /// Return if this type is a primitive type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsPrimitive => false;
    /// <summary>
    /// Return if this type is an arithmetic (float or integer) type.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public bool IsArithmetic => IsInteger || IsFloat;

    /// <summary>
    /// Return if this type has a knowable size at runtime.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)] 
    public virtual bool IsSized => true;
    
    /// <summary>
    /// Return if this type can be dereferenced to represent a
    /// singular element.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)] 
    public virtual bool IsDereferencable => false;
    /// <summary>
    /// Return the type produced by dereferencing a value of this type,
    /// or none if this is not a dereferenceable type.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)] 
    public virtual Option<RecType> Deref => Option.None;
    
    /// <summary>
    /// Return the type produced by indexing a value of this type,
    /// or none if this is not an indexable type.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)] 
    public virtual Option<RecType> Element => Option.None;

    /// <summary>
    /// Return if this type contains an error type.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)] 
    public bool ContainsError => this.Contains(static t => t is ErrorType);

    /// <summary>
    /// Return if this type is the builtin 'none' type.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)] 
    public bool IsNone => this is NoneType;

    /// <summary>
    /// Return if this type is 'structural' (i.e. a struct or instantiation
    /// of a generic struct).
    /// </summary>
    [FieldOption(PrintLevel.Hidden)]
    public virtual bool IsStructural => false;

    /// <summary>
    /// If this type is structural, return an array of its fields.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)]
    public virtual Option<Field[]> Fields => Option.None;

    /// <summary>
    /// Return if this type is 'template' (i.e. a non-instantiated generic struct).
    /// These types cannot be used as the type of a variable of expression.
    /// </summary>
    [FieldOption(PrintLevel.Hidden)]
    public virtual bool IsTemplate => false;

    /// <summary>
    /// Return if this type can be copied bitwise without needing to mark its
    /// original location as moved-from.
    /// </summary>
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool TriviallyCopyable => true;

    public abstract bool Equals(RecType? other);
    public sealed override bool Equals(object? other)
        => (other is RecType t) && Equals(t);
    public abstract override int GetHashCode();

    public static bool operator ==(RecType? a, RecType? b)
        => object.Equals(a, b);
    public static bool operator !=(RecType? a, RecType? b)
        => !(a == b);

    /// <summary>
    /// Get the location at which this type was defined, or SourceSpan.Builtin
    /// if there is no such location.
    /// </summary>
    public virtual SourceSpan GetDefinitionLocation() => SourceSpan.Builtin;
    /// <summary>
    /// Return the field corresponding to the provided identifier, or none
    /// if it either does not exist or this is not a structural type.
    /// </summary>
    public virtual Option<Field> FindField(Identifier name) => Option.None;
    
    /// <summary>
    /// Apply a set of substitutions to this type, returning a new type
    /// which may potentially be reference equal to this type.
    /// </summary>
    public virtual RecType ApplySubstitutions(TypeSubstitutions substitutions)
        => this;

    /// <summary>
    /// Create a pointer type wrapping the provided type.
    /// </summary>
    public static PointerType Pointer(RecType type)
        => new() { Pointee = type };
    /// <summary>
    /// Create a reference type wrapping the provided type.
    /// </summary>
    public static ReferenceType Reference(RecType type)
        => new() { Referee = type };
    /// <summary>
    /// Create an array type wrapping the provided type.
    /// </summary>
    public static ArrayType Array(RecType type)
        => new() { Elem = type };
        
    public virtual void PropogateVisitor<V>(V visitor)
        where V : IVisitor, allows ref struct
    { }
}
