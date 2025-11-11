using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateVariable(VariableExpression context)
    {
        var ptr = Function.VariableMappings.Seconds[context.Variable];
        return Builder.BuildInst(context, new InstructionKind.Load(ptr));
    }

    private ValueID GenerateVariableAsLHS(VariableExpression context)
    {
        return Function.VariableMappings.Seconds[context.Variable];
    }
}