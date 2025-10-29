using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public RecValue CompileDot(DotExpression context)
    {
        var ptr = CompileDotAsLHS(context);
        return CTX.Builder.BuildLoad2(context.Type.Compile(CTX), ptr.Unwrap());
    }

    public RecValue CompileDotAsLHS(DotExpression context)
    {
        var val = CompileAsLHS(context.Inner);
        return CTX.Builder.BuildStructGEP2(
            context.Inner.Type.Compile(CTX), 
            val.Unwrap(), 
            (uint)context.FieldIndex);
    }
}