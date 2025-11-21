using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitArrayDirectExpr([NotNull] RecParser.ArrayDirectExprContext context)
    {
        var vals = (Expression[])[..
            from element in context._Elements
            select Visit(element).UnwrapAs<Expression>()
        ];

        var type = vals[0].Type;
        var anyErrors = false;

        foreach(var val in vals)
        {
            if(val.Type != type)
            {
                CTX.Diagnostics.AddError(
                    val.Span, Errors.ArrayLitTypeMismatch(type, val.Type));
                
                anyErrors = true;
            }
        }

        if(anyErrors)
            return BoundSyntax.ErrorExpression(context, CTX);

        return new ArrayExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = RecType.Array(type),
            Values = vals
        };
    }

    public override BoundSyntax VisitArrayRepeatExpr([NotNull] RecParser.ArrayRepeatExprContext context)
    {
        var val = Visit(context.Element).UnwrapAs<Expression>();
        var count = Visit(context.Count).UnwrapAs<Expression>();

        count = Coerce(count, CTX.BuiltinTypes.USize);

        var anyErrors = false;

        if(!val.Type.TriviallyCopyable)
        {
            CTX.Diagnostics.AddError(
                val.Span, Errors.ArrayRepNonTrivial(val.Type));

            anyErrors = true;
        }

        if(count.Type != CTX.BuiltinTypes.USize)
        {
            CTX.Diagnostics.AddError(
                count.Span, Errors.TypeMismatch(CTX.BuiltinTypes.USize, count.Type));

            anyErrors = true;
        }

        if(anyErrors)
            return BoundSyntax.ErrorExpression(context, CTX);

        return new ArrayRepeatExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = RecType.Array(val.Type),
            ValueToRepeat = val,
            Count = count,
        };
    }

    public override BoundSyntax VisitArrayRawExpr([NotNull] RecParser.ArrayRawExprContext context)
    {
        var ptr = Visit(context.Pointer).UnwrapAs<Expression>();
        var count = Visit(context.Count).UnwrapAs<Expression>();

        count = Coerce(count, CTX.BuiltinTypes.USize);
        CheckUnsafe(context);
        
        var anyErrors = false;

        if(ptr.Type is not PointerType)
        {
            CTX.Diagnostics.AddError(
                count.Span, Errors.ArrayPtrNotPtr(ptr.Type));

            anyErrors = true;
        }

        if(count.Type != CTX.BuiltinTypes.USize)
        {
            CTX.Diagnostics.AddError(
                count.Span, Errors.TypeMismatch(CTX.BuiltinTypes.USize, count.Type));

            anyErrors = true;
        }

        if(anyErrors)
            BoundSyntax.ErrorExpression(context, CTX);

        return new ArrayRawExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = RecType.Array(ptr.Type.Deref.Unwrap()),
            Ptr = ptr,
            Count = count
        };
    }
}