using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class NoneType : NamedType
{
    public override LLVMValueRef BuildDestructor(RecContext ctx)
        => ctx.EmptyDestructor;

    public override FieldDescriptor[] GetFields(RecContext ctx)
        => [];

    protected override LLVMTypeRef BuildLLVMType(RecContext ctx)
        => ctx.LLVM.VoidType;
}
