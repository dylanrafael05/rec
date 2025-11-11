using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateBlock(Block context)
    {
        var block = Function.NewBlock();

        Builder.BuildInst(context, new InstructionKind.Goto(block));
        Builder.PositionAtEnd(block);

        foreach(var stmt in context.Syntax)
        {
            Generate(stmt);
        }
    }
}