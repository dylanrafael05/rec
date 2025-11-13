using Antlr4.Runtime.Misc;
using Re.C.Antlr;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitSizeofExpression([NotNull] RecParser.SizeofExpressionContext context)
    {
        var type = CTX.Resolvers.Type.Visit(context.TargetType);

        if(type.ContainsError)
            return BoundSyntax.ErrorExpression(context, CTX);
        
        if(!type.IsSized)
        {
            CTX.Diagnostics.AddError(context.Sizeof().Symbol.SourceSpan, 
                Errors.SizeofUnsizedType(type));
        }

        return new SizeofExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = CTX.BuiltinTypes.USize,
            Target = type
        };
    }
}