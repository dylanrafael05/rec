using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateIf(IfStatement context)
    {
        var cond = Generate(context.Condition);

        var then = Function.NewBlock();
        var @else = Function.NewBlock();
        var end = Function.NewBlock();

        Builder.BuildInst(CTX.BuiltinTypes.None, context.Condition.Span, 
            new InstructionKind.Branch(cond, then, @else));

        // 'then' block
        Builder.PositionAtEnd(then);

        Generate(context.Then);
        Builder.BuildInst(CTX.BuiltinTypes.None, context.Condition.Span,
            new InstructionKind.Goto(end));

        // 'else' block (or none)
        Builder.PositionAtEnd(@else);

        if(context.Else.IsT0)
        {
            Generate(context.Else.AsT0);
        }
        else if(context.Else.IsT1)
        {
            Generate(context.Else.AsT1);
        }

        Builder.BuildInst(CTX.BuiltinTypes.None, context.Condition.Span,
            new InstructionKind.Goto(end));

        // 'end' block (empty but required to be in valid state)
        Builder.PositionAtEnd(end);
    }
}