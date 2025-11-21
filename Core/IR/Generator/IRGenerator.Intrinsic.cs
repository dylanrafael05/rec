using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateLeakIntrinsic(IntrinsicExpression context)
    {
        if(context.Args is not [VariableExpression arg])
            return Builder.BuildError(context);

        var argc = Function.VariableMappings.Get(arg.Variable);
        var varinst = Function.InstructionByValue(argc);
        var leaked = Builder.Build(varinst.Type, context.Span, new InstructionKind.Leak(argc));

        // NOTE: this is really ugly, and means that second passes through the IR will
        // be invalid!
        Function.RebindVariable(arg.Variable, leaked);
        return leaked;
    }

    public ValueID GenerateIntrinsic(IntrinsicExpression context)
    {
        return context.Intrinsic switch
        {
            Intrinsic.Leak => GenerateLeakIntrinsic(context),
            _ => throw Unimplemented
        };
    }
}