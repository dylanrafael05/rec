using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateVariable(VariableExpression context)
    {
        var ptr = VariableLinks[context.Variable];
        return Builder.BuildInst(context, new InstructionKind.Load(ptr));
    }

    private ValueID GenerateVariableAsLHS(VariableExpression context)
    {
        return VariableLinks[context.Variable];
    }
}