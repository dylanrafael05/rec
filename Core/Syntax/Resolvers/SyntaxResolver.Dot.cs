using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitDotExpression([NotNull] RecParser.DotExpressionContext context)
    {
        var span = context.CalculateSourceSpan();
        var inner = Visit(context.Base).UnwrapAs<Expression>();
        var fieldname = context.Field.TextAsIdentifier;

        if(inner.Type is ArrayType arrayType)
        {
            // Nasty special case! Arrays have two psuedo-fields 'size' and 'ptr'
            if(fieldname == Identifier.Builtin.Size)
            {
                return new DotExpression
                {
                    Span = span,
                    Type = CTX.BuiltinTypes.USize,
                    Inner = inner,
                    Field = DotField.ArraySize
                };
            }
            else if(fieldname == Identifier.Builtin.Ptr)
            {
                return new DotExpression
                {
                    Span = span,
                    Type = RecType.Pointer(arrayType.Elem),
                    Inner = inner,
                    Field = DotField.ArrayPtr
                };
            }

            CTX.Diagnostics.AddError(
                span, Errors.UndefinedField(arrayType, fieldname));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

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
                span, Errors.UndefinedField(inner.Type, fieldname));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        return new DotExpression
        {
            Span = span,
            Type = field.Unwrap().Type,
            Inner = inner,
            Field = DotField.Struct(field.Unwrap().Index)
        };
    }
}