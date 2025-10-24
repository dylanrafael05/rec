using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;

using static Re.C.Syntax.UnaryOperator;

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
            if(inner.Type is not PointerType { Pointee: var pointee })
            {
                CTX.Diagnostics.AddError(
                    span, Errors.InvalidDereference(inner.Type));

                return BoundSyntax.ErrorExpression(span, CTX);
            }

            return new DerefExpression
            {
                Span = span,
                Type = pointee,
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
                Type = new PointerType { Pointee = inner.Type },
                Inner = inner
            };
        }

        throw Unimplemented;
    }
}