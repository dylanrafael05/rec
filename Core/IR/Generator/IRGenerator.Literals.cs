using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateInt(IntLiteral context)
        => Builder.BuildInst(context, new InstructionKind.IntLiteral(context.Value));

    private ValueID GenerateFloat(FloatLiteral context)
        => Builder.BuildInst(context, new InstructionKind.FloatLiteral(context.Value));
    
    private ValueID GenerateString(StringLiteral context)
        => Builder.BuildInst(context, new InstructionKind.StringLiteral(context.Value));
}