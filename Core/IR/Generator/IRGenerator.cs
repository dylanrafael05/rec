using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public partial class IRGenerator(RecContext CTX)
{
    public IRBuilder Builder => CTX.IRBuilder;
    public IRFunction Function => CTX.Functions.Current.UnwrapNull().IRFunction.Unwrap();

    public Scoped<LoopBlocks>.Optional Loops { get; } = new();

    public void LinkVariable(Variable var, ValueID id)
    {
        Function.BindVariable(var, Builder.Build(
            RecType.Pointer(var.Type), 
            var.DefinitionLocation, 
            new InstructionKind.Local(id)));
    }

    public void RealizeFunction(Function function)
    {
        // External functions need not be realized //
        if (function.IsExternal)
            return;
        
        // Set up the context state //
        CTX.Functions.Enter(function);
        CTX.Scopes.Enter(function.InnerScope);

        // Set up the builder position //
        var fn = new IRFunction(function);
        function.IRFunction = Option.Some(fn);
        var block = fn.NewBlock(CTX.Scopes.Current);

        Builder.PositionAtEnd(block);

        // Link all arguments to variables so they may be treated
        // as assignable
        for(var i = 0; i < function.ArgumentCount; i++)
        {
            var arg = Builder.Build(
                function.Type.Parameters[i],
                function.ArgumentDefs[i].UnwrapNull().DefinitionLocation,
                new InstructionKind.Argument(i)
            );

            LinkVariable(function.ArgumentDefs[i].UnwrapNull(), arg);
        }

        // Compile the function's body //
        Generate(function.Body.Unwrap());
        fn.SetFinalBlock(Builder.CurrentBlock.UnwrapNull());

        // Restore the context state //
        CTX.Scopes.Exit();
        CTX.Functions.Exit();
    }

    /// <summary>
    /// Compile a statement or expression.
    /// </summary>
    public void Generate(BoundSyntax context)
    {
        switch(context)
        {
            case Block x:
                GenerateBlock(x);
                return;

            case ReturnStatement x:
                GenerateReturn(x);
                return;
                
            case LetStatement x:
                GenerateLet(x);
                return;

            case IfStatement x:
                GenerateIf(x);
                return;

            case WhileStatement x:
                GenerateWhile(x);
                return;

            case AssignStatement x:
                GenerateAssign(x);
                return;
            
            case ErrorStatement x:
                GenerateError(x);
                return;

            case BreakStructStatement x:
                GenerateBreakStruct(x);
                return;

            case BreakStatement x:
                GenerateBreak(x);
                return;

            case ContinueStatement x:
                GenerateContinue(x);
                return;
            
            case Expression x:
                Generate(x);
                return;
            
            default: 
                throw UnimplementedBecause($"context type {context.GetType()}");
        }
    }
    
    /// <summary>
    /// Compile an expression, returning the value associated with the result of the
    /// expression.
    /// </summary>
    public ValueID Generate(Expression context)
    {
        return context switch
        {
            IntLiteral x => GenerateInt(x),
            FloatLiteral x => GenerateFloat(x),
            StringLiteral x => GenerateString(x),
            CallExpression x => GenerateCall(x),
            FunctionExpression x => GenerateFunctionRef(x),
            BinaryExpression x => GenerateBinary(x),
            VariableExpression x => GenerateVariable(x),
            UnaryExpression x => GenerateUnary(x),
            CastExpression x => GenerateCast(x),
            DerefExpression x => GenerateDeref(x),
            AddressOfExpression x => GenerateAddrOf(x),
            TempAddressOfExpression x => GenerateTempAddrOf(x),
            DotExpression x => GenerateDot(x),
            StructExpression x => GenerateStruct(x),
            SizeofExpression x => GenerateSizeof(x),
            IntrinsicExpression x => GenerateIntrinsic(x),
            IndexExpression x => GenerateIndex(x),
            ArrayExpression x => GenerateArray(x),
            ArrayRepeatExpression x => GenerateArrayRepeat(x),
            ArrayRawExpression x => GenerateArrayRaw(x),
            ErrorExpression x => GenerateError(x),

            _ => throw UnimplementedBecause($"context type {context.GetType()}")
        };
    }

    /// <summary>
    /// Compile an expression as though it were on the left hand side of
    /// an assignment operator. Returns the associated pointer value.
    /// </summary>
    public ValueID GenerateAsLHS(Expression context)
    {
        return context switch
        {
            VariableExpression x => GenerateVariableAsLHS(x),
            DerefExpression x => GenerateDerefAsLHS(x),
            DotExpression x => GenerateDotAsLHS(x),
            IndexExpression x => GenerateIndexAsLHS(x),

            _ => throw UnimplementedBecause($"context type {context.GetType()}")
        };
    }
}