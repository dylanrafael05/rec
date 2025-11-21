using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateWhile(WhileStatement context)
    {
        var beginLoop = Function.NewBlock(CTX.Scopes.Current);
        var loopBody = Function.NewBlock(CTX.Scopes.Current);
        var endLoop = Function.NewBlock(CTX.Scopes.Current);

        Loops.Enter(new(beginLoop, endLoop));

        Builder.Build(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Goto(beginLoop));

        // Condition //
        Builder.PositionAtEnd(beginLoop);
        var cond = Generate(context.Condition);
        Builder.TryBuildBranch(context.Span, cond, loopBody, endLoop);

        // Body //
        Builder.PositionAtEnd(loopBody);
        Generate(context.Then);
        Builder.TryBuildGoto(context.Span, beginLoop);

        // End loop //
        Builder.PositionAtEnd(endLoop);
        Loops.Exit();
    }
}