using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Syntax;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateUnary(InstructionKind.Unary un, Instruction inst)
    {
        var op = ValueOf(un.Op);
        var t = CurrentFunction.InstructionByValue(un.Op).Type;
        var b = CTX.Builder;

        return Option.Some(un.Operator switch
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
        });
    }
}