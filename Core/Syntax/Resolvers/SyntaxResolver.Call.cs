using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitCallExpression([NotNull] RecParser.CallExpressionContext context)
    {
        // Bind the function and check that it *is* a function
        var fn = Visit(context.Target).UnwrapAs<Expression>();

        var fnType = fn.Type switch
        {
            FunctionType x => x,
            PointerType { Pointee: FunctionType x } => x,
            _ => null
        };

        if(fnType is null)
        {
            CTX.Diagnostics.AddError(
                fn.Span,
                Errors.CallToNonFunctionType(fn.Type));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        // Bind arguments and check that they match the function's signature
        var args = (Expression[])[..
            from arg in context._Args
            select Visit(arg).UnwrapAs<Expression>()
        ];

        var argTypes = from a in args select a.Type;

        if (!argTypes.SequenceEqual(fnType.Parameters))
        {
            CTX.Diagnostics.AddError(
                fn.Span,
                Errors.InvalidCallToFunction(fnType, argTypes));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        return new CallExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = fnType.Return,
            Function = fn,
            Args = args
        };
    }
}