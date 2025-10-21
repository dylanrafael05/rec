using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public void Compile(ReturnStatement context)
    {
        var val = Compile(context.Value);

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