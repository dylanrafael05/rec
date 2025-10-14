using LLVMSharp.Interop;
using Re.C.Types.Descriptors;
using Re.C.Visitor;

namespace Re.C.Types;

public class PointerType : Type
{
    public required Type Pointee { get; init; }

    public override bool Equals(Type? other)
        => other is PointerType t
        && t.Pointee.Equals(Pointee);
    public override int GetHashCode()
        => HashCode.Combine(Pointee);

    public override string Name => $"*{Pointee.Name}";
    public override string FullName => $"*{Pointee.FullName}";

    public override LLVMValueRef BuildDestructor(RecContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(RecContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(RecContext ctx)
        => LLVMTypeRef.CreatePointer(Pointee.GetLLVMType(ctx), 0);

    public override void PropogateVisitor<V>(V visitor)
        => visitor.Visit(Pointee);
}
