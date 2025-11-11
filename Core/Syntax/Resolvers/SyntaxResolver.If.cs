using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitIfStatement([NotNull] RecParser.IfStatementContext context)
    {
        // Visit constituent parts //
        var condition = Visit(context.Cond).UnwrapAs<Expression>();
        var block = Visit(context.Body).UnwrapAs<Block>();

        // Visit tail //
        OneOf<IfStatement, Block, Unit> tail = context.Tail switch
        {
            RecParser.ElseStatementContext @else => Visit(@else.EndBlock).UnwrapAs<Block>(),
            RecParser.ElifStatementContext @elif => Visit(@elif.Elif).UnwrapAs<IfStatement>(),
            null => Unit(),

            _ => throw Unimplemented
        };

        // Error on non-boolean condition //
        if (condition.Type != CTX.BuiltinTypes.Bool)
        {
            CTX.Diagnostics.AddError(
                condition.Span,
                Errors.InvalidConditionType(condition.Type));
        }

        return new IfStatement
        {
            Span = context.CalculateSourceSpan(),
            Condition = condition,
            Then = block,
            Else = tail
        };
    }
}