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
        out Expression callTargetExpr,
        out FunctionType? functionType)
    {
        targetExpr = Visit(context.Target).UnwrapAs<Expression>();

        if(context.MethodMarker is not null)
        {
            var identPT = context.MethodMarker.Identifier();
            var ident = Identifier.Name(
                identPT.GetText());

            var fndef = CTX.TypeAssociations.SearchOrDiagnose(
                identPT.CalculateSourceSpan(),
                targetExpr.Type,
                ident,
                CTX.CurrentImports);

            if(fndef is not Function fn)
            {
                CTX.Diagnostics.AddError(
                    context.CalculateSourceSpan(), Errors.InvalidMethod(fndef));
                
                callTargetExpr = BoundSyntax.ErrorExpression(identPT, CTX);
                functionType = default;
            }
            else 
            {
                callTargetExpr = new FunctionExpression
                {
                    Span = identPT.CalculateSourceSpan(),
                    Type = fn.Type,
                    Function = fn
                };

                functionType = fn.Type;
            }
        }
        else
        {
            callTargetExpr = targetExpr;
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
        GetCallTarget(context, out var targetExpr, out var callTarget, out var fnType);

        if(fnType is null)
        {
            CTX.Diagnostics.AddError(
                targetExpr.Span,
                Errors.CallToNonFunctionType(targetExpr.Type));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        // Bind arguments and check that they match the function's signature
        var args = (Expression[])[
            ..Option.If(!ReferenceEquals(targetExpr, callTarget), targetExpr),
            ..from arg in context._Args
            select Visit(arg).UnwrapAs<Expression>()
        ];

        var argTypes = from a in args select a.Type;

        if (!argTypes.SequenceEqual(fnType.Parameters))
        {
            CTX.Diagnostics.AddError(
                callTarget.Span,
                Errors.InvalidCallToFunction(fnType, argTypes));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        return new CallExpression
        {
            Span = context.CalculateSourceSpan(),
            Type = fnType.Return,
            Function = callTarget,
            Args = args
        };
    }
}