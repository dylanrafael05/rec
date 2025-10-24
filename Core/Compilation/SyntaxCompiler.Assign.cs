using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private void CompileAssign(AssignStatement context)
    {
        var target = CompileAsLHS(context.Target).Unwrap();
        var value = Compile(context.Value).Unwrap();

        CTX.Builder.BuildStore(value, target);
    }
}