using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public void GenerateBreak(BreakStatement brk)
    {
        Builder.Build(brk, new InstructionKind.Goto(Loops.Current.Unwrap().End));
    }

    public void GenerateContinue(ContinueStatement cont)
    {
        Builder.Build(cont, new InstructionKind.Goto(Loops.Current.Unwrap().Begin));
    }
}