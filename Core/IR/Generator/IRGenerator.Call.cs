using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateCall(CallExpression context)
    {
        var args = (ValueID[])[..
            from arg in context.Args select Generate(arg)
        ];

        var fnValue = Generate(context.Function);
        var fnType = context.Function.Type;

        Assert(fnType is FunctionType);

        return Builder.BuildInst(context, 
            new InstructionKind.Call(fnValue, args));
    }
}