using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public class IRBuilder(RecContext CTX)
{
    public InstructionBlock? CurrentBlock { get; private set; }
    public int CurrentIndex { get; private set; }
    public bool CurrentBlockIsComplete => CurrentBlock.UnwrapNull().IsComplete;

    public void PositionAtEnd(InstructionBlock block)
    {
        CurrentBlock = block;
        CurrentIndex = block.Instructions.Count;
    }

    /// <summary>
    /// Build an instruction, panicking if the current block is complete.
    /// </summary>
    public ValueID Build(RecType type, SourceSpan span, InstructionKind kind)
    {
        if(CurrentBlockIsComplete)
            throw Panic($"Attempt to build an expression in a completed block.");

        var instruction = new Instruction(type, span, kind);
        return CurrentBlock.UnwrapNull().InsertInstruction(CurrentIndex++, instruction);
    }

    public ValueID BuildNoop(BoundSyntax expr, ValueID inner)
    {
        var innerInstruction = CurrentBlock.UnwrapNull().Function.InstructionByValue(inner);
        return Build(
            innerInstruction.Type,
            expr.Span,
            new InstructionKind.Noop(inner));
    }

    public ValueID BuildError(BoundSyntax expr)
    {
        return Build(CTX.BuiltinTypes.Error, expr.Span, new InstructionKind.Error());
    }
    
    /// <summary>
    /// Build an instruction, panicking if the current block is complete.
    /// </summary>
    public ValueID Build(BoundSyntax expr, InstructionKind kind)
    {
        return Build(
            expr.As<Expression>().Map(static x => x.Type).Or(CTX.BuiltinTypes.None), 
            expr.Span, kind);
    }

    /// <summary>
    /// Attempts to build a goto instruction if the current block is not already complete.
    /// Returns 'true' if goto was successfully built.
    /// </summary>
    public bool TryBuildGoto(SourceSpan span, InstructionBlock blk)
    {
        if(CurrentBlockIsComplete)
            return false;

        Build(CTX.BuiltinTypes.None, span, new InstructionKind.Goto(blk));
        return true;
    }

    /// <summary>
    /// Attempts to build a branch instruction if the current block is not already complete.
    /// Returns 'true' if branch was successfully built.
    /// </summary>
    public bool TryBuildBranch(SourceSpan span, ValueID cond, InstructionBlock onTrue, InstructionBlock onFalse)
    {
        if(CurrentBlockIsComplete)
            return false;

        Build(CTX.BuiltinTypes.None, span, new InstructionKind.Branch(cond, onTrue, onFalse));
        return true;
    }

    /// <summary>
    /// Attempts to build an instruction if the current block is not already complete.
    /// Returns the associated value id if instruction was successfully built.
    /// </summary>
    public Option<ValueID> TryBuildInst(RecType type, SourceSpan span, InstructionKind kind)
    {
        if(CurrentBlockIsComplete)
            return Option.None;
        
        return Option.Some(Build(type, span, kind));
    }
}