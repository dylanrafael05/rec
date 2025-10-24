using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private void CompileIf(IfStatement context)
    {
        var cond = Compile(context.Condition).Unwrap();

        var then = CTX.CurrentLLVMFunction.AppendBasicBlock("then");
        var end = CTX.CurrentLLVMFunction.AppendBasicBlock("end");

        CTX.Builder.BuildCondBr(cond, then, end);
        CTX.Builder.PositionAtEnd(then);

        Compile(context.Then);

        CTX.Builder.PositionAtEnd(end);

        if(context.Else.IsT0)
        {
            CompileIf(context.Else.AsT0);
        }
        else if(context.Else.IsT1)
        {
            Compile(context.Else.AsT1);
        }
    }
}