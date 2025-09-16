using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class PointerType : Type
{
    public required Type Pointee { get; init; }

    public override string Name => $"*{Pointee.Name}";
    public override string FullName => $"*{Pointee.FullName}";

    public override LLVMValueRef BuildDestructor(CodegenContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(CodegenContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(CodegenContext ctx)
        => LLVMTypeRef.CreatePointer(Pointee.GetLLVMType(ctx), 0);
}
