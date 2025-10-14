using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;

using static Re.C.Syntax.UnaryOperator;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    private delegate bool UnaryTypeResolver(
        RecContext ctx,
        UnaryOperator op,
        Types.Type operand,
        ref Types.Type result,
        ref string error);

    private Expression HandleUnary(
        SourceSpan span,
        Expression visitedOperand,
        UnaryOperator op,
        UnaryTypeResolver resolver)
    {
        // Fail early if operand is an error
        if (visitedOperand.Type.ContainsError)
            return visitedOperand;

        // Check for type errors based on the resolver
        var resultType = CTX.BuiltinTypes.Error;
        var errorMsg = "";

        if (!resolver(CTX, op, visitedOperand.Type, ref resultType, ref errorMsg))
        {
            // Fail fast if resolver behaves incorrectly
            if (errorMsg.Length is 0)
                throw Panic($"resolver did not set error message on error");

            // Emit error and return error expression
            CTX.Diagnostics.AddError(span, errorMsg);

            return new ErrorExpression
            {
                Span = span,
                Type = CTX.BuiltinTypes.Error
            };
        }

        // Fail fast if resolver did not behave as expected
        if (resultType is ErrorType)
            throw Panic($"Failed to set resultType on success");

        // Construct resulting BST node
        return new UnaryExpression
        {
            Span = span,

            Type = resultType,
            Operator = op,

            Operand = visitedOperand
        };
    }

    public override BoundSyntax VisitUnaryExpression([NotNull] RecParser.UnaryExpressionContext context)
    {
        var opText = context.Op.GetText();
        var op = UnaryOperator.FromRepr(opText);

        var operand = Visit(context.Operand).UnwrapAs<Expression>();
        var span = context.CalculateSourceSpan();

        return op switch
        {
            Posit or Negate =>
                HandleUnary(
                    span, operand, op,
                    static (CTX, op, operand, ref result, ref error) =>
                    {
                        if (operand.IsArithmetic)
                        {
                            result = operand;
                            return true;
                        }

                        error = Errors.InvalidUnaryType(op, operand);
                        return false;
                    }
                ),

            BitNot =>
                HandleUnary(
                    span, operand, op,
                    static (CTX, op, operand, ref result, ref error) =>
                    {
                        if (operand.IsInteger)
                        {
                            result = operand;
                            return true;
                        }

                        error = Errors.InvalidUnaryType(op, operand);
                        return false;
                    }
                ),

            LogicNot =>
                HandleUnary(
                    span, operand, op,
                    static (CTX, op, operand, ref result, ref error) =>
                    {
                        if (operand == CTX.BuiltinTypes.Bool)
                        {
                            result = operand;
                            return true;
                        }

                        error = Errors.InvalidUnaryType(op, operand);
                        return false;
                    }
                ),

            _ => throw Unimplemented
        };
    }
}