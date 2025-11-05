using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateUnary(UnaryExpression context)
    {
        var op = Generate(context.Operand);
        return Builder.BuildInst(context, new InstructionKind.Unary(op, context.Operator));
    }
}