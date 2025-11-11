using Antlr4.Runtime.Misc;
using Re.C.Types;

using static Re.C.Syntax.BinaryOperator;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    private delegate bool BinaryTypeResolver(
        RecContext ctx,
        BinaryOperator op,
        RecType lhs,
        RecType rhs,
        ref RecType result,
        ref string error);

    private Expression HandleBinary(
        RecParser.BinaryExpressionContext bin,
        BinaryOperator op,
        BinaryTypeResolver resolver)
    {
        // Expressionize the lhs and rhs
        var lhsOut = Visit(bin.LHS).UnwrapAs<Expression>();
        var rhsOut = Visit(bin.RHS).UnwrapAs<Expression>();

        // Fail early if either operand contains an error
        if (lhsOut.Type.ContainsError)
            return lhsOut;

        if (rhsOut.Type.ContainsError)
            return rhsOut;

        // Check for type errors using the provided resolver
        var allSpan = SourceSpan.Combine(lhsOut.Span, rhsOut.Span);
        var resultType = CTX.BuiltinTypes.Error;
        var errorMsg = "";

        if (!resolver(CTX, op, lhsOut.Type, rhsOut.Type, ref resultType, ref errorMsg))
        {
            // Fail fast if resolver did not behave as expected
            if (errorMsg.Length is 0)
                throw Panic($"Failed to set errorMsg on failure");

            // Emit error and return error expression
            CTX.Diagnostics.AddError(allSpan, errorMsg);

            return new ErrorExpression
            {
                Span = allSpan,
                Type = CTX.BuiltinTypes.Error
            };
        }
        
        // Fail fast if resolver did not behave as expected
        if (resultType is ErrorType)
            throw Panic($"Failed to set resultType on success");

        // Construct resulting BST node
        return new BinaryExpression
        {
            Span = allSpan,

            Type = resultType,
            Operator = op,

            LHS = lhsOut,
            RHS = rhsOut
        };
    }

    public override BoundSyntax VisitBinaryExpression([NotNull] RecParser.BinaryExpressionContext context)
    {
        // Get then switch over the operator in the binary expression
        var op = BinaryOperator.FromRepr(context.GetChild(1).GetText());

        return op switch
        {
            // Arithmetic operations //
            Add or Subtract or Multiply or Divide or Modulo =>
                HandleBinary(
                    context, op, 
                    static (CTX, op, lhs, rhs, ref result, ref error) =>
                    {
                        if (lhs == rhs && lhs.IsArithmetic)
                        {
                            result = lhs;
                            return true;
                        }

                        if (lhs is PointerType && rhs.IsInteger)
                        {
                            result = lhs;
                            return true;
                        }

                        error = Errors.InvalidBinaryTypes(op, lhs, rhs);
                        return false;
                    }
                ),

            // Equality operations //
            CompEq or CompNe =>
                HandleBinary(
                    context, op,
                    static (CTX, op, lhs, rhs, ref result, ref error) =>
                    {
                        if (lhs == rhs && (lhs is PointerType || lhs.IsPrimitive))
                        {
                            result = CTX.BuiltinTypes.Bool;
                            return true;
                        }

                        error = Errors.InvalidBinaryTypes(op, lhs, rhs);
                        return false;
                    }
                ),

            // Comparison operations //
            CompLe or CompLEq or CompGr or CompGEq =>
                HandleBinary(
                    context, op,
                    static (CTX, op, lhs, rhs, ref result, ref error) =>
                    {
                        if (lhs == rhs && (lhs is PointerType || lhs.IsArithmetic))
                        {
                            result = CTX.BuiltinTypes.Bool;
                            return true;
                        }

                        error = Errors.InvalidBinaryTypes(op, lhs, rhs);
                        return false;
                    }
                ),

            // Bitwise operations //
            BitAnd or BitOr or BitXor or BitLeft or BitRight =>
                HandleBinary(
                    context, op,
                    static (CTX, op, lhs, rhs, ref result, ref error) =>
                    {
                        if (lhs == rhs && lhs.IsInteger)
                        {
                            result = lhs;
                            return true;
                        }

                        error = Errors.InvalidBinaryTypes(op, lhs, rhs);
                        return false;
                    }
                ),

            // Logical operations //
            LogicAnd or LogicOr => 
                HandleBinary(
                    context, op,
                    static (CTX, op, lhs, rhs, ref result, ref error) =>
                    {
                        if (lhs == rhs && lhs == CTX.BuiltinTypes.Bool)
                        {
                            result = lhs;
                            return true;
                        }

                        error = Errors.InvalidBinaryTypes(op, lhs, rhs);
                        return false;
                    }
                ),
                
            _ => throw Unimplemented
        };
    }
}