using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitDotExpression([NotNull] RecParser.DotExpressionContext context)
    {
        var span = context.CalculateSourceSpan();
        var inner = Visit(context.Base).UnwrapAs<Expression>();
        var fieldname = context.Field.TextAsIdentifier;

        if(inner.Type is not StructType asStruct)
        {
            CTX.Diagnostics.AddError(
                span, Errors.InvalidDotTarget(inner.Type));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        var field = asStruct.FindField(fieldname);

        if(field.IsNone)
        {
            CTX.Diagnostics.AddError(
                span, Errors.UndefinedStructField(inner.Type, fieldname));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        return new DotExpression
        {
            Span = span,
            Type = field.Unwrap().Type,
            Inner = inner,
            FieldIndex = field.Unwrap().Index
        };
    }
}