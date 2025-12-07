using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateVariable(VariableExpression context)
    {
        var ptr = GenerateVariableAsLHS(context);
        return Builder.Build(context, new InstructionKind.Load(ptr));
    }

    private ValueID GenerateVariableAsLHS(VariableExpression context)
    {
        return Builder.BuildNoop(
            context,
            Function.VariableMappings.Get(context.Variable));
    }
}