using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public RecValue CompileDot(DotExpression context)
    {
        var value = Compile(context.Inner);
        return CTX.Builder.BuildExtractValue(value.Unwrap(), (uint)context.FieldIndex);
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