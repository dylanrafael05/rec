using Antlr4.Runtime.Misc;
using Re.C.Antlr;

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