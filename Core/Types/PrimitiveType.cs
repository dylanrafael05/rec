
namespace Re.C.Types;

public class PrimitiveType(PrimitiveType.Class cls, Option<int> minIntegerDepth) : NamedType
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
    public override Option<int> MinIntegerDepth => minIntegerDepth;
    public override bool IsSigned => cls is Class.SignedInt;
    public override bool IsBool => cls is Class.Bool;
    public override bool IsPrimitive => true;
}
