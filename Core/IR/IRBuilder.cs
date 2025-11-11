using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public class IRBuilder(RecContext CTX)
{
    public InstructionBlock? CurrentBlock { get; private set; }
    public int CurrentIndex { get; private set; }

    public void PositionAtEnd(InstructionBlock block)
    {
        CurrentBlock = block;
        CurrentIndex = block.Instructions.Count;
    }

    public ValueID BuildInst(RecType type, SourceSpan span, InstructionKind kind)
    {
        var instruction = new Instruction(type, span, kind);
        return CurrentBlock.UnwrapNull().InsertInstruction(CurrentIndex++, instruction);
    }
    
    public ValueID BuildInst(BoundSyntax expr, InstructionKind kind)
        => BuildInst(
            expr.As<Expression>().Map(static x => x.Type).Or(CTX.BuiltinTypes.None), 
            expr.Span, kind);
}