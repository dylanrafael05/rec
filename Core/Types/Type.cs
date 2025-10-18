using LLVMSharp.Interop;
using Re.C.Types.Descriptors;
using Re.C.Visitor;

namespace Re.C.Types;

public abstract class Type : IEquatable<Type>, IVisitable
{
    public override string ToString()
        => FullName;

    public abstract string Name { get; }
    public abstract string FullName { get; }

    public virtual bool IsSigned => false;
    public virtual bool IsInteger => false;
    public virtual bool IsFloat => false;
    public virtual bool IsPrimitive => false;
    public bool IsArithmetic => IsInteger || IsFloat;
    public bool ContainsError => this.Contains(static t => t is ErrorType);

    public abstract bool Equals(Type? other);
    public sealed override bool Equals(object? other)
        => (other is Type t) && Equals(t);
    public abstract override int GetHashCode();

    public static bool operator ==(Type? a, Type? b)
        => object.Equals(a, b);
    public static bool operator !=(Type? a, Type? b)
        => !(a == b);

    protected abstract LLVMTypeRef BuildLLVMType(RecContext ctx);
    public abstract LLVMValueRef BuildDestructor(RecContext ctx);
    public abstract FieldDescriptor[] GetFields(RecContext ctx);

    public LLVMTypeRef GetLLVMType(RecContext ctx)
    {
        if (ctx.TypeCache.TryGetValue(this, out var result))
            return result;

        result = BuildLLVMType(ctx);
        ctx.TypeCache[this] = result;

        return result;
    }

    public virtual void PropogateVisitor<V>(V visitor)
        where V : IVisitor, allows ref struct
    { }
}
