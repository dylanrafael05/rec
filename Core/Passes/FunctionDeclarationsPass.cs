using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class FunctionDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        var span = context.CalculateSourceSpan();

        // Get the type of the function from its signature
        var type = new FunctionType
        {
            Parameters = [..
                from arg in context._Args
                select CTX.Resolvers.Type.Visit(arg.typename())
            ],

            Return = context.Ret is null
                ? CTX.BuiltinTypes.None
                : CTX.Resolvers.Type.Visit(context.Ret)
        };

        var argNames = (Identifier[])[..
            from arg in context._Args
            select arg.Identifier().TextAsIdentifier
        ];

        // Define arguments in an anonymous inner scope
        var innerScope = new Scope 
        { 
            Identifier = Identifier.None, 
            Parent = CTX.CurrentScope 
        };

        var argInfo = argNames
            .Zip(type.Parameters)
            .Zip(context._Args);

        var argDefs = (Variable?[])[..
            from info in argInfo
                let name = info.First.First
                let argtype = info.First.Second
                let syntax = info.Second
                select innerScope.DefineOrDiagnose(CTX, syntax.CalculateSourceSpan(), new Variable
                {
                    Type = argtype,
                    Identifier = name
                })
        ];

        // Create the function definition object, but do not
        // yet assign its LLVM function reference (this will be done after
        // defining it in the current scope).
        var function = new Function
        {
            ArgumentNames = argNames,

            Identifier = context.Name.TextAsIdentifier,
            Type = type,

            InnerScope = innerScope,
            ArgumentDefs = argDefs,

            IsExternal = context.External() is not null
        };

        context.DefinedFunction = CTX.CurrentScope.DefineOrDiagnose(
            CTX, span, function);

        // Report errors for invalid usage of 'external'
        if(function.IsExternal && context.Body != null)
        {
            CTX.Diagnostics.AddError(
                span, Errors.BodyForExtern(function.Identifier));
        }
        else if(!function.IsExternal && context.Body == null)
        {
            CTX.Diagnostics.AddError(
                span, Errors.NoBodyForNonExtern(function.Identifier));
        }

        // If we have succeeded, create the LLVM function
        if (context.DefinedFunction is not null)
        {
            // TODO: mangle names here?
            function.LLVMFunction = Option.Some(
                CTX.Module.AddFunction(function.FullName, function.Type.Compile(CTX)));
        }

        return default;
    }
}