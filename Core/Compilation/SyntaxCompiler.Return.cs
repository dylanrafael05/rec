using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public void CompileReturn(ReturnStatement context)
    {
        var val = context.Value.Map(Compile).Or(RecValue.None);

        if (val.Value.IsSome(out var value))
        {
            CTX.Builder.BuildRet(value);
        }
        else
        {
            CTX.Builder.BuildRetVoid();
        }
    }
}