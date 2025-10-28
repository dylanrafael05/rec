using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    private void GetCallTarget(
        RecParser.CallExpressionContext context, 
        out Expression targetExpr,
        out OneOf<CallExpression.DirectTarget, CallExpression.MethodTarget> target,
        out FunctionType? functionType)
    {
        targetExpr = Visit(context.Target).UnwrapAs<Expression>();

        if(context.MethodMarker is not null)
        {
            var identPT = context.MethodMarker.Identifier();
            var ident = Identifier.Name(
                identPT.GetText(),
                targetExpr.Type);

            var fndef = CTX.Scopes.Current.SearchOrDiagnose(
                identPT.CalculateSourceSpan(), ident, CTX.CurrentImports);

            if(fndef is not Function fn)
            {
                CTX.Diagnostics.AddError(
                    context.CalculateSourceSpan(), Errors.InvalidMethod(fndef));
                
                target = default;
                functionType = default;
            }
            else 
            {
                target = new CallExpression.MethodTarget(targetExpr, fn);
                functionType = fn.Type;
            }
        }
        else
        {
            target = new CallExpression.DirectTarget(targetExpr);
            functionType = targetExpr.Type switch
            {
                FunctionType x => x,
                PointerType { Pointee: FunctionType x } => x,
                _ => null
            };
        }
    }

    public override BoundSyntax VisitCallExpression([NotNull] RecParser.CallExpressionContext context)
    {
        // Bind the function and check that it *is* a function
        GetCallTarget(context, out var targetExpr, out var target, out var fnType);

        if(fnType is null)
        {
            CTX.Diagnostics.AddError(
                targetExpr.Span,
                Errors.CallToNonFunctionType(targetExpr.Type));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        // Bind arguments and check that they match the function's signature
        var args = (Expression[])[
            ..from arg in context._Args
            select Visit(arg).UnwrapAs<Expression>()
        ];

        // TODO: 
        // pickup from here; revert to call expression with single format
        // insert 'self' into parameter types when checked.

        var argTypes = from a in args select a.Type;

        if (!argTypes.SequenceEqual(fnType.Parameters))
        {
            CTX.Diagnostics.AddError(
                target.Span,
                Errors.InvalidCallToFunction(fnType, argTypes));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        return new CallExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = fnType.Return,
            Target = target,
            Args = args
        };
    }
}