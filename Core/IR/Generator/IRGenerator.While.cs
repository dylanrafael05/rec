using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateWhile(WhileStatement context)
    {
        var beginLoop = Function.NewBlock();
        var loopBody = Function.NewBlock();
        var endLoop = Function.NewBlock();

        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Goto(beginLoop));

        // Condition //
        Builder.PositionAtEnd(beginLoop);
        var cond = Generate(context.Condition);
        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Branch(cond, loopBody, endLoop));

        // Body //
        Builder.PositionAtEnd(loopBody);
        Generate(context.Then);
        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Goto(beginLoop));

        // End loop //
        Builder.PositionAtEnd(endLoop);
    }
}