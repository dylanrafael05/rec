using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitCallExpression([NotNull] RecParser.CallExpressionContext context)
    {
        var fn = Visit(context.Target).UnwrapAs<Expression>();
    }
}