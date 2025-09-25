using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class PointerType : Type
{
    public required Type Pointee { get; init; }

    public override string Name => $"*{Pointee.Name}";
    public override string FullName => $"*{Pointee.FullName}";

    public override LLVMValueRef BuildDestructor(ProgramContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(ProgramContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(ProgramContext ctx)
        => LLVMTypeRef.CreatePointer(Pointee.GetLLVMType(ctx), 0);
}
