using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitIndexExpression([NotNull] RecParser.IndexExpressionContext context)
    {
        var array = Visit(context.Target).UnwrapAs<Expression>();
        var index = Visit(context.Index).UnwrapAs<Expression>();

        index = Coerce(index, CTX.BuiltinTypes.USize);

        var anyErrors = false;

        if(array.Type is not ArrayType)
        {
            CTX.Diagnostics.AddError(
                array.Span, Errors.InvalidIndexExprTarget(array.Type));

            anyErrors = true;
        }

        if(index.Type != CTX.BuiltinTypes.USize)
        {
            CTX.Diagnostics.AddError(
                index.Span, Errors.InvalidIndexExprIndex(CTX.BuiltinTypes.USize, array.Type));
        }

        if(anyErrors)
            return BoundSyntax.ErrorExpression(context, CTX);

        return new IndexExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = array.Type.Element.Unwrap(),
            Target = array,
            Index = index
        };
    }
}