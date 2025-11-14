using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateVariable(VariableExpression context)
    {
        var ptr = Function.VariableMappings.Get(context.Variable);
        return Builder.Build(context, new InstructionKind.Load(ptr));
    }

    private ValueID GenerateVariableAsLHS(VariableExpression context)
    {
        return Builder.BuildNoop(
            context,
            Function.VariableMappings.Get(context.Variable));
    }
}