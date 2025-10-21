using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public void Compile(Block context)
    {
        foreach(var stmt in context.Syntax)
        {
            Compile(stmt);
        }
    }
}