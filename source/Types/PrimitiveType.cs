using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class PrimitiveType(LLVMTypeRef type) : NamedType
{
    public override LLVMValueRef BuildDestructor(CodegenContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(CodegenContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(CodegenContext ctx)
        => type;
}
