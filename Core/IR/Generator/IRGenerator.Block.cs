using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateBlock(Block context)
    {
        var block = Function.NewBlock(context.Scope);
        CTX.Scopes.Enter(context.Scope);

        Builder.Build(context, new InstructionKind.Goto(block));
        Builder.PositionAtEnd(block);

        var i = 0;
        foreach(var stmt in context.Syntax)
        {
            Generate(stmt);
            i++;

            if(Builder.CurrentBlockIsComplete)
            {
                if(i != context.Syntax.Length)
                {
                    var span = SourceSpan.Combine(context.Syntax[i + 1].Span, context.Syntax[^1].Span);
                    CTX.Diagnostics.AddWarning(span, Warnings.UnreachableCode());

                    break;
                }
            }
        }

        CTX.Scopes.Exit();

        //! SAFETY !//
        // If the current block is complete, it must be due to a user leaving this block,
        // and therefore we have no reason to exit this block manually. Note that 'if' and 'while'
        // should *force* the builder to leave the current block.
        if(!Builder.CurrentBlockIsComplete)
        { 
            var after = Function.NewBlock(CTX.Scopes.Current);
            Builder.TryBuildGoto(context.Span, after);
            Builder.PositionAtEnd(after);
        }
    }
}