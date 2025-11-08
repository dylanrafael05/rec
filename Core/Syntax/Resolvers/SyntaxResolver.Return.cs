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

        var value = Option.Nonnull(context.Value)
            .Map(Visit)
            .Map(x => x.UnwrapAs<Expression>());

        var type = value.Map(x => x.Type).Or(CTX.BuiltinTypes.None);
        var expectedType = CTX.Functions.Current.UnwrapNull().Type.Return;

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