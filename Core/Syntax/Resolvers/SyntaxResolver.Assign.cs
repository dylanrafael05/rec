using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitAssignStatement([NotNull] RecParser.AssignStatementContext context)
    {
        // Visit constituent parts //
        var span = context.CalculateSourceSpan();
        var target = Visit(context.Target).UnwrapAs<Expression>();
        var value = Visit(context.Value).UnwrapAs<Expression>();

        // Error on mismatched types or un-assignable target //
        if (target.Type != value.Type)
        {
            CTX.Diagnostics.AddError(
                span,
                Errors.TypeMismatch(target.Type, value.Type));
        }

        if (!target.Assignable)
        {
            CTX.Diagnostics.AddError(
                target.Span,
                Errors.InvalidAssignmentTarget());
        }

        return new AssignStatement
        {
            Span = span,
            Target = target,
            Value = value
        };
    }
}