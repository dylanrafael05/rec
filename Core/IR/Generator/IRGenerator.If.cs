using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateIf(IfStatement context)
    {
        var cond = Generate(context.Condition);

        var then = Function.NewBlock();
        var @else = Function.NewBlock();
        var end = Function.NewBlock();

        Builder.TryBuildBranch(context.Condition.Span, cond, then, @else);

        // 'then' block
        Builder.PositionAtEnd(then);

        Generate(context.Then);
        Builder.TryBuildGoto(context.Condition.Span, end);

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

        Builder.TryBuildGoto(context.Condition.Span, end);

        // 'end' block (empty but required to be in valid state)
        Builder.PositionAtEnd(end);
    }
}