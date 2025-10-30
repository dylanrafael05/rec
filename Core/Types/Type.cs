using LLVMSharp.Interop;
using Re.C.Types.Descriptors;
using Re.C.Visitor;

namespace Re.C.Types;

public abstract class Type : IEquatable<Type>, IVisitable
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
    public bool ContainsError => this.Contains(static t => t is ErrorType);

    public abstract bool Equals(Type? other);
    public sealed override bool Equals(object? other)
        => (other is Type t) && Equals(t);
    public abstract override int GetHashCode();

    public static bool operator ==(Type? a, Type? b)
        => object.Equals(a, b);
    public static bool operator !=(Type? a, Type? b)
        => !(a == b);

    protected abstract LLVMTypeRef ImplementCompile(RecContext ctx);
    public abstract LLVMValueRef BuildDestructor(RecContext ctx);
    public abstract FieldDescriptor[] GetFields(RecContext ctx);
    public virtual Option<SourceSpan> GetDefinitionLocation() => Option.None;

    public LLVMTypeRef Compile(RecContext ctx)
    {
        if (ctx.TypeCache.TryGetValue(this, out var result))
            return result;

        result = ImplementCompile(ctx);
        ctx.TypeCache[this] = result;

        return result;
    }

    public virtual void PropogateVisitor<V>(V visitor)
        where V : IVisitor, allows ref struct
    { }

    /// <summary>
    /// Create a pointer type wrapping the provided type.
    /// </summary>
    public static PointerType Pointer(Type type)
        => new() { Pointee = type };
}
