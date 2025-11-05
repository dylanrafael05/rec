using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

using Type = Re.C.Types.Type;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateBinary(BinaryExpression context)
    {
        if(context.Operator is BinaryOperator.LogicAnd)
            return CompileAnd(context);

        if(context.Operator is BinaryOperator.LogicOr)
            return CompileOr(context);

        var lhs = Generate(context.LHS);
        var rhs = Generate(context.RHS);

        return Builder.BuildInst(context, new InstructionKind.Binary(lhs, rhs, context.Operator));
    }

    private ValueID CompileAnd(BinaryExpression context)
    {
        // Compute the lhs value
        var lhs = Generate(context.LHS);
        var beginBlock = Builder.CurrentBlock.UnwrapNull();

        // Short circuit on lhs=false
        var onTrue = Function.NewBlock();
        var final = Function.NewBlock();

        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Branch(lhs, onTrue, final));
        
        // Otherwise, compute rhs
        Builder.PositionAtEnd(onTrue);
        var rhs = Generate(context.RHS);
        onTrue = Builder.CurrentBlock.UnwrapNull();
        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Goto(final));

        // Return a phi instruction
        Builder.PositionAtEnd(final);

        return Builder.BuildInst(context, 
            new InstructionKind.Phi([
                new(beginBlock, lhs),
                new(onTrue, rhs),
            ]));
    }
    
    private ValueID CompileOr(BinaryExpression context)
    {
        // Compute the lhs value
        var lhs = Generate(context.LHS);
        var beginBlock = Builder.CurrentBlock.UnwrapNull();

        // Short circuit on lhs=true
        var onFalse = Function.NewBlock();
        var final = Function.NewBlock();

        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Branch(lhs, final, onFalse));
        
        // Otherwise, compute rhs
        Builder.PositionAtEnd(onFalse);
        var rhs = Generate(context.RHS);
        onFalse = Builder.CurrentBlock.UnwrapNull();
        Builder.BuildInst(CTX.BuiltinTypes.None, context.Span, 
            new InstructionKind.Goto(final));

        // Return a phi instruction
        Builder.PositionAtEnd(final);

        return Builder.BuildInst(context, 
            new InstructionKind.Phi([
                new(beginBlock, lhs),
                new(onFalse, rhs),
            ]));
    }
}