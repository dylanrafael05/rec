using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitLetStmt([NotNull] RecParser.LetStmtContext context)
    {
        // TODO: this
        throw Todo;

        // return new LetStatement
        // {
        //     Span = context.CalculateSourceSpan(),

        // };
    }
}