using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileFunctionRef(FunctionExpression context)
        => context.Function.LLVMFunction.Unwrap();
}