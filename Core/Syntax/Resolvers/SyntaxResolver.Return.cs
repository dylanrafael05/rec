using Antlr4.Runtime.Misc;
using Re.C.Antlr;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitReturnStatement([NotNull] RecParser.ReturnStatementContext context)
    {
        var span = context.CalculateSourceSpan();
        var expectedType = CTX.Functions.Current.UnwrapNull().Type.Return;

        var value = Option.Nonnull(context.Value)
            .Map(Visit)
            .Map(x => x.UnwrapAs<Expression>())
            .Map(x => Coerce(x, expectedType));

        var type = value.Map(x => x.Type).Or(CTX.BuiltinTypes.None);

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