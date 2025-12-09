using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateCast(CastExpression context)
    {
        var inner = Generate(context.Value);
        return Builder.Build(context, new InstructionKind.BuiltinCast(inner));
    }
}