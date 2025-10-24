using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class PrimitiveType(LLVMTypeRef type, PrimitiveType.Class cls) : NamedType
{
    public enum Class
    {
        UnsignedInt,
        SignedInt,
        Float,
        Bool,
        Other
    }

    public override bool IsFloat => cls is Class.Float;
    public override bool IsInteger => cls is Class.UnsignedInt or Class.SignedInt;
    public override bool IsSigned => cls is Class.SignedInt;
    public override bool IsBool => cls is Class.Bool;
    public override bool IsPrimitive => true;

    public override LLVMValueRef BuildDestructor(RecContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(RecContext ctx)
        => [];
    protected override LLVMTypeRef ImplementCompile(RecContext ctx)
        => type;
}
