using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    private bool CheckCast(IParseTree cast, RecType from, RecType to)
    {
        if(from is ReferenceType fromRef && to is PointerType toPtr && fromRef.Referee == toPtr.Pointee)
            return true;

        if(from is PointerType fromPtr && to is ReferenceType toRef && fromPtr.Pointee == toRef.Referee)
        {
            CheckUnsafe(cast);
            return true;
        }

        return (from, to) is
            (PointerType, PointerType) or
            ({ IsArithmetic: true }, { IsArithmetic: true });
    }

    public override BoundSyntax VisitCastExpression([NotNull] RecParser.CastExpressionContext context)
    {
        var span = context.CalculateSourceSpan();

        var inner = Visit(context.Operand).UnwrapAs<Expression>();
        var type = CTX.Resolvers.Type.Visit(context.TargetType);

        // Check if cast is valid, and report error otherwise //        
        if(!CheckCast(context, inner.Type, type))
        {
            CTX.Diagnostics.AddError(
                span, Errors.InvalidCast(type, inner.Type));
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