using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public RecValue Compile(FunctionExpression context)
        => context.Function.LLVMFunction.Unwrap();
}