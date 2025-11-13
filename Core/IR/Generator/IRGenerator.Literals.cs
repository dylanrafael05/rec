using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateInt(IntLiteral context)
        => Builder.Build(context, new InstructionKind.IntLiteral(context.Value));

    private ValueID GenerateFloat(FloatLiteral context)
        => Builder.Build(context, new InstructionKind.FloatLiteral(context.Value));
    
    private ValueID GenerateString(StringLiteral context)
        => Builder.Build(context, new InstructionKind.StringLiteral(context.Value));
}