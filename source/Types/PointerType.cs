using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class PointerType : Type
{
    public required Type Pointee { get; init; }

    public override string Name => $"*{Pointee.Name}";
    public override string FullName => $"*{Pointee.FullName}";

    public override LLVMValueRef BuildDestructor(RecContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(RecContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(RecContext ctx)
        => LLVMTypeRef.CreatePointer(Pointee.GetLLVMType(ctx), 0);
}
