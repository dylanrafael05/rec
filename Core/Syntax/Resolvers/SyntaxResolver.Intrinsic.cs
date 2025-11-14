using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitIntrinsicExpression([NotNull] RecParser.IntrinsicExpressionContext context)
    {
        var intrinsicName = context.IntrinsicName.Text;

        try
        {
            var intrinsic = Intrinsic.FromRepr(intrinsicName);

            var args = (Expression[])[..
                from arg in context._Args select
                Visit(arg).UnwrapAs<Expression>()
            ];
            var types = (RecType[])[..
                from arg in args select arg.Type
            ];

            // Leak intrinsic; requires a single variable-expression argument
            if(intrinsic is Intrinsic.Leak)
            {
                if(args is not [VariableExpression])
                {
                    CTX.Diagnostics.AddError(
                        context.CalculateSourceSpan(), 
                        Errors.BadIntrinsicTypes(intrinsicName, types));

                    return BoundSyntax.ErrorExpression(context, CTX);
                }

                return new IntrinsicExpression
                {
                    Span = context.CalculateSourceSpan(),
                    Type = CTX.BuiltinTypes.None,
                    Args = args,
                    Intrinsic = Intrinsic.Leak
                };
            }

            // Store uninit; requires a pointer then the value to assign to it
            if(intrinsic is Intrinsic.StoreUninit)
            {
                if(types is not [PointerType { Pointee: var ptr }, var pte] || ptr != pte)
                {
                    CTX.Diagnostics.AddError(
                        context.CalculateSourceSpan(), 
                        Errors.BadIntrinsicTypes(intrinsicName, types));

                    return BoundSyntax.ErrorExpression(context, CTX);
                }
                
                return new IntrinsicExpression
                {
                    Span = context.CalculateSourceSpan(),
                    Type = CTX.BuiltinTypes.None,
                    Args = args,
                    Intrinsic = Intrinsic.StoreUninit
                };
            }

            throw Unimplemented;
        }
        catch(EnumReprException)
        {
            CTX.Diagnostics.AddError(
                context.CalculateSourceSpan(), 
                Errors.UnknownIntrinsic(intrinsicName));

            return BoundSyntax.ErrorExpression(context, CTX);
        }
    }
}