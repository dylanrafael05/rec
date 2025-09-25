using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class PrimitiveType(LLVMTypeRef type) : NamedType
{
    public override LLVMValueRef BuildDestructor(ProgramContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(ProgramContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(ProgramContext ctx)
        => type;
}
