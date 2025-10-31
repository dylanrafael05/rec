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
            var identPT = context.MethodMarker;
            var ident = identPT.TextAsIdentifier;

            var fndef = CTX.TypeAssociations.SearchOrDiagnose(
                identPT.SourceSpan,
                targetExpr.Type,
                ident,
                CTX.CurrentImports);

            if(fndef is not Function fn)
            {
                CTX.Diagnostics.AddError(
                    context.CalculateSourceSpan(), Errors.InvalidMethod(fndef));
                
                callTargetExpr = BoundSyntax.ErrorExpression(identPT.SourceSpan, CTX);
                functionType = default;
            }
            else 
            {
                callTargetExpr = new FunctionExpression
                {
                    Span = identPT.SourceSpan,
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
        var hasReceiver = !ReferenceEquals(targetExpr, callTarget);

        if(fnType is null)
        {
            CTX.Diagnostics.AddError(
                targetExpr.Span,
                Errors.CallToNonFunctionType(targetExpr.Type));

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        // Bind arguments and check that they match the function's signature
        var args = (Expression[])[
            ..Option.If(hasReceiver, targetExpr),
            ..from arg in context._Args
            select Visit(arg).UnwrapAs<Expression>()
        ];

        // Allocate a temporary (or use actual reference when available)
        // if declared receiver type is pointer to actual receiver type
        if(hasReceiver 
        && fnType.Parameters[0] is var pointer and PointerType { Pointee: var pointee }
        && pointee == args[0].Type)
        {
            args[0] = new TempAddressOfExpression
            {
                Span = args[0].Span,
                Type = pointer,
                Inner = args[0]
            };
        }

        // Check for type mismatches
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