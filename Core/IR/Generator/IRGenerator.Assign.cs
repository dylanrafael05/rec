using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateAssign(AssignStatement context)
    {
        var target = GenerateAsLHS(context.Target);
        var value = Generate(context.Value);

        Builder.Build(context, new InstructionKind.Store(target, value));
    }
}