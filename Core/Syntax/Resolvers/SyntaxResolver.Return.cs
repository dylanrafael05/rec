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
        var span = context.CalculateSourceSpan();

        // TODO: swap this to an option instead of a nullable
        var value = (context.Value is null ? null : Visit(context.Value))
            .UnwrapAsOrNull<Expression>();

        var type = value?.Type ?? CTX.BuiltinTypes.None;
        var expectedType = CTX.Functions.Current.UnwrapNull().Type.Return;

        // TODO: how should definely-returns analysis take place?

        // Error on mismatching return type //
        if (type != expectedType)
        {
            CTX.Diagnostics.AddError(
                span, Errors.TypeMismatch(expectedType, type));
        }

        return new ReturnStatement
        {
            Span = context.CalculateSourceSpan(),
            Value = value
        };
    }
}