using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitCastExpression([NotNull] RecParser.CastExpressionContext context)
    {
        var span = context.CalculateSourceSpan();

        var inner = Visit(context.Operand).UnwrapAs<Expression>();
        var type = CTX.Resolvers.Type.Visit(context.TargetType);

        // Check if cast is valid, and report error otherwise //
        var canCast = (inner.Type, type) is 
            (PointerType, PointerType) or 
            ({ IsArithmetic: true }, { IsArithmetic: true });
        
        if(!canCast)
        {
            CTX.Diagnostics.AddError(
                span, Errors.InvalidCast(inner.Type, type));
        }
        else if(inner.Type == type)
        {
            // Additionally, warn on cast-to-self //
            CTX.Diagnostics.AddWarning(
                span, Warnings.UnnecessaryCast());
        }

        return new CastExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = type,
            Value = inner
        };
    }
}