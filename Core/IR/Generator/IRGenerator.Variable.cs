using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateVariable(VariableExpression context)
    {
        var ptr = GenerateVariableAsLHS(context);
        return Builder.Build(context, new InstructionKind.Load(ptr));
    }

    private ValueRef GenerateVariableAsLHS(VariableExpression context)
    {
        return ValueRef.WithSpan(
            Function.VariableMappings.Get(context.Variable),
            context.Span);
    }
}