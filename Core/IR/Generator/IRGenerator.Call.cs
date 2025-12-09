using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateCall(CallExpression context)
    {
        var args = (ValueRef[])[..
            from arg in context.Args select Generate(arg)
        ];

        var fnValue = Generate(context.Function);
        var fnType = context.Function.Type;

        Assert(fnType is FunctionType);

        return Builder.Build(context, 
            new InstructionKind.Call(fnValue, args));
    }
}