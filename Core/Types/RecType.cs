using Re.C.Visitor;

namespace Re.C.Types;

public abstract class RecType : IEquatable<RecType>, IVisitable
{
    public override string ToString()
        => FullName;

    [FieldOption(PrintLevel.Hidden)] 
    public abstract string Name { get; }
    public abstract string FullName { get; }

    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsBool => false;
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsSigned => false;
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsInteger => false;
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsFloat => false;
    [FieldOption(PrintLevel.Verbose)] 
    public virtual bool IsPrimitive => false;
    [FieldOption(PrintLevel.Verbose)] 
    public bool IsArithmetic => IsInteger || IsFloat;
    [FieldOption(PrintLevel.Hidden)] 
    public virtual bool IsSized => true;
    [FieldOption(PrintLevel.Hidden)] 
    public virtual bool IsDereferencable => false;
    [FieldOption(PrintLevel.Hidden)] 
    public virtual Option<RecType> Deref => Option.None;
    [FieldOption(PrintLevel.Hidden)] 
    public bool ContainsError => this.Contains(static t => t is ErrorType);
    [FieldOption(PrintLevel.Verbose)] 
    public bool IsNone => this is NoneType;

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

    public virtual SourceSpan GetDefinitionLocation() => SourceSpan.Builtin;

    public virtual void PropogateVisitor<V>(V visitor)
        where V : IVisitor, allows ref struct
    { }

    /// <summary>
    /// Create a pointer type wrapping the provided type.
    /// </summary>
    public static PointerType Pointer(RecType type)
        => new() { Pointee = type };
    public static ReferenceType Reference(RecType type)
        => new() { Referee = type };
}
