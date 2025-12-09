using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueRef GenerateSizeof(SizeofExpression context)
    {
        return Builder.Build(context, new InstructionKind.Sizeof(context.Target));
    }
}