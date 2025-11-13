using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitBreakStatement([NotNull] RecParser.BreakStatementContext context)
    {
        return new BreakStatement
        {
            Span = context.CalculateSourceSpan()
        };
    }

    public override BoundSyntax VisitContinueStatement([NotNull] RecParser.ContinueStatementContext context)
    {
        return new ContinueStatement
        {
            Span = context.CalculateSourceSpan()
        };
    }
}