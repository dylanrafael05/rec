using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler(RecContext CTX)
{
    public void RealizeFunction(Function function)
    {
        // External functions need not be realized //
        if (function.IsExternal)
            return;

        // Set up the builder position //
        var fn = function.LLVMFunction.Unwrap();
        fn.AppendBasicBlock("entry");

        CTX.Builder.ClearInsertionPosition();
        CTX.Builder.PositionAtEnd(fn.FirstBasicBlock);

        // Set up the context state //
        var prevFn = CTX.CurrentFunction;
        CTX.CurrentFunction = function;

        // Link all arguments to variables so they may be treated
        // as assignable
        for(var i = 0; i < function.ArgumentCount; i++)
        {
            LinkVariable(
                function.ArgumentDefs[i].UnwrapNull(), 
                fn.GetParam((uint)i));
        }

        // Compile the function's body //
        Compile(function.Body.Unwrap());

        // Restore the context state //
        CTX.CurrentFunction = prevFn;
    }

    /// <summary>
    /// Compile a statement or expression.
    /// </summary>
    public void Compile(BoundSyntax context)
    {
        switch(context)
        {
            case ReturnStatement x:
                CompileReturn(x);
                return;
                
            case LetStatement x:
                CompileLet(x);
                return;

            case IfStatement x:
                CompileIf(x);
                return;

            case WhileStatement x:
                CompileWhile(x);
                return;

            case AssignStatement x:
                CompileAssign(x);
                return;
            
            case Expression x:
                Compile(x);
                return;
            
            default: 
                throw UnimplementedBecause($"context type {context.GetType()}");
        }
    }
    
    /// <summary>
    /// Compile an expression, returning the value associated with the result of the
    /// expression.
    /// </summary>
    public RecValue Compile(Expression context)
    {
        return context switch
        {
            IntLiteral x => CompileInt(x),
            FloatLiteral x => CompileFloat(x),
            StringLiteral x => CompileString(x),
            CallExpression x => CompileCall(x),
            FunctionExpression x => CompileFunctionRef(x),
            BinaryExpression x => CompileBinary(x),
            VariableExpression x => CompileVariable(x),
            UnaryExpression x => CompileUnary(x),
            CastExpression x => CompileCast(x),
            DerefExpression x => CompileDeref(x),
            AddressOfExpression x => CompileAddrOf(x),

            _ => throw UnimplementedBecause($"context type {context.GetType()}")
        };
    }

    /// <summary>
    /// Compile an expression as though it were on the left hand side of
    /// an assignment operator. Returns the associated pointer value.
    /// </summary>
    public RecValue CompileAsLHS(Expression context)
    {
        return context switch
        {
            VariableExpression x => CompileVariableAsLHS(x),
            DerefExpression x => CompileDerefAsLHS(x),

            _ => throw UnimplementedBecause($"context type {context.GetType()}")
        };
    }
}