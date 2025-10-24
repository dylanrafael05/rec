using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private void CompileWhile(WhileStatement context)
    {
        var beginLoop = CTX.CurrentLLVMFunction.AppendBasicBlock("begin_while");
        var loopBody = CTX.CurrentLLVMFunction.AppendBasicBlock("loop_body");
        var endLoop = CTX.CurrentLLVMFunction.AppendBasicBlock("exit_loop");

        CTX.Builder.BuildBr(beginLoop);

        // Condition //
        CTX.Builder.PositionAtEnd(beginLoop);
        var cond = Compile(context.Condition).Unwrap();
        CTX.Builder.BuildCondBr(cond, loopBody, endLoop);

        // Body //
        CTX.Builder.PositionAtEnd(loopBody);
        Compile(context.Then);
        CTX.Builder.BuildBr(beginLoop);

        // End loop //
        CTX.Builder.PositionAtEnd(endLoop);
    }
}