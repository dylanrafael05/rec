using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Re.C.Antlr;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver(RecContext CTX) : RecBaseVisitor<BoundSyntax>
{
    protected override BoundSyntax AggregateResult(BoundSyntax aggregate, BoundSyntax nextResult)
    {
        if (aggregate is not null && nextResult is not null)
            throw Panic("Cannot aggregate multiple syntaxes!");

        if (aggregate is not null)
            return aggregate;

        return nextResult!;
    }

    private void CheckUnsafe(IParseTree tree)
    {
        if(!CTX.UnsafeScope.Current)
        {
            CTX.Diagnostics.AddError(
                tree.CalculateSourceSpan(),
                Errors.UnsafeOperation());
        }
    }

    public override BoundSyntax VisitUnsafeBlock([NotNull] RecParser.UnsafeBlockContext context)
    {
        CTX.UnsafeScope.Enter();
        var result = Visit(context.block());
        CTX.UnsafeScope.Exit();

        return result;
    }

    public override BoundSyntax VisitUnsafeExpression([NotNull] RecParser.UnsafeExpressionContext context)
    {
        CTX.UnsafeScope.Enter();
        var result = Visit(context.expression());
        CTX.UnsafeScope.Exit();

        return result;
    }
}