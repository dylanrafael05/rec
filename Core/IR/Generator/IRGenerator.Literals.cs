using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateInt(IntLiteral context)
        => Builder.Build(context, new InstructionKind.IntLiteral(context.Value));

    private ValueRef GenerateFloat(FloatLiteral context)
        => Builder.Build(context, new InstructionKind.FloatLiteral(context.Value));
    
    private ValueRef GenerateString(StringLiteral context)
        => Builder.Build(context, new InstructionKind.StringLiteral(context.Value));
}