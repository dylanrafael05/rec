using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitMemoryExpression([NotNull] RecParser.MemoryExpressionContext context)
    {
        var inner = Visit(context.Operand).UnwrapAs<Expression>();
        var span = context.CalculateSourceSpan();

        if(context.Op is RecParser.DereferenceOperatorContext)
        {
            // Dereference operator //
            if(!inner.Type.IsDereferencable)
            {
                CTX.Diagnostics.AddError(
                    span, Errors.InvalidDereference(inner.Type));

                return BoundSyntax.ErrorExpression(span, CTX);
            }

            if(inner.Type is PointerType)
            {
                CheckUnsafe(context);
            }

            return new DerefExpression
            {
                Span = span,
                Type = inner.Type.Deref.Unwrap(),
                Inner = inner
            };
        }
        else if(context.Op is RecParser.AddressofOperatorContext)
        {
            // Address of operator //
            if(!inner.HasAddress)
            {
                CTX.Diagnostics.AddError(
                    span, Errors.InvalidAddressOf());

                return BoundSyntax.ErrorExpression(span, CTX);
            }

            return new AddressOfExpression
            {
                Span = span,
                Type = RecType.Reference(inner.Type),
                Inner = inner
            };
        }

        throw Unimplemented;
    }
}