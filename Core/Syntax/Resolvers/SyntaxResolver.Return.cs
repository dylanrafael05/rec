using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitReturnStatement([NotNull] RecParser.ReturnStatementContext context)
    {
        var value = Visit(context.Value).UnwrapAs<Expression>();
        var expectedType = CTX.CurrentFunction.UnwrapNull().Type.Return;

        // TODO: how should definely-returns analysis take place?

        // Error on mismatching return type //
        if (value.Type != expectedType)
        {
            CTX.Diagnostics.AddError(
                value.Span,
                Errors.TypeMismatch(expectedType, value.Type));
        }

        return new ReturnStatement
        {
            Span = context.CalculateSourceSpan(),
            Value = value
        };
    }
}