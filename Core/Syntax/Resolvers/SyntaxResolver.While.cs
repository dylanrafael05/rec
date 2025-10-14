using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitWhileStatement([NotNull] RecParser.WhileStatementContext context)
    {
        var condition = Visit(context.Cond).UnwrapAs<Expression>();
        var block = Visit(context.Body).UnwrapAs<Block>();

        if (condition.Type != CTX.BuiltinTypes.Bool)
        {
            CTX.Diagnostics.AddError(
                condition.Span,
                Errors.InvalidConditionType(condition.Type));
        }

        return new WhileStatement
        {
            Span = context.CalculateSourceSpan(),
            Condition = condition,
            Then = block
        };
    }
}