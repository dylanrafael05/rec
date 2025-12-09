using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateUnary(UnaryExpression context)
    {
        var op = Generate(context.Operand);
        return Builder.Build(context, new InstructionKind.Unary(op, context.Operator));
    }
}