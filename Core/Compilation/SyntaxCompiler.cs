using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler(RecContext ctx)
{
    public RecContext CTX { get; } = ctx;

    public void CompileFunction(Function function)
    {
        if (function.IsExternal)
            return;

        var fn = function.LLVMFunction.Unwrap();
        fn.AppendBasicBlock("entry");

        CTX.Builder.ClearInsertionPosition();
        CTX.Builder.PositionAtEnd(fn.FirstBasicBlock);

        Compile(function.Body.Unwrap());
    }

    public void Compile(BoundSyntax context)
    {
        switch(context)
        {
            case ReturnStatement x:
                Compile(x);
                return;
            
            case Expression x:
                Compile(x);
                return;
            
            default: throw Unimplemented;
        }

        throw Unimplemented;
    }
    
    public RecValue Compile(Expression context)
    {
        return context switch
        {
            IntLiteral x => Compile(x),
            FloatLiteral x => Compile(x),
            StringLiteral x => Compile(x),
            CallExpression x => Compile(x),
            FunctionExpression x => Compile(x),

            _ => throw Unimplemented
        };
    }
}