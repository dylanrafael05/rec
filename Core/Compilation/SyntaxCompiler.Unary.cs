using Re.C.Syntax;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileUnary(UnaryExpression context)
    {
        var op = Compile(context.Operand).Unwrap();
        var t = context.Operand.Type;
        var b = CTX.Builder;

        return context.Operator switch
        {
            UnaryOperator.BitNot or UnaryOperator.LogicNot => t switch 
            {
                { IsInteger: true } or { IsBool: true }
                    => b.BuildNot(op),

                _ => throw Unimplemented,
            },

            UnaryOperator.Negate => t switch
            {
                { IsInteger: true }
                    => b.BuildNeg(op),

                { IsFloat: true }
                    => b.BuildFNeg(op),

                _ => throw Unimplemented,
            },

            UnaryOperator.Posit => op,

            _ => throw Unimplemented
        };
    }
}