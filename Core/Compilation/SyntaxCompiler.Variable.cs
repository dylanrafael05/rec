using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileVariable(VariableExpression context)
    {
        // TODO: handle variables of type none
        var ptr = context.Variable.LLVMPointerValue.Unwrap();
        return CTX.Builder.BuildLoad2(context.Variable.Type.Compile(CTX), ptr);
    }

    private RecValue CompileVariableAsLHS(VariableExpression context)
    {
        return context.Variable.LLVMPointerValue.Unwrap();
    }
}