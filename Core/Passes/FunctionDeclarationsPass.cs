using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class FunctionDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
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

        // Create the function definition object, but do not
        // yet assign its LLVM function reference (this will be done after
        // defining it in the current scope).
        var function = new Function
        {
            ArgumentNames = [..
                from arg in context._Args
                select arg.Identifier().TextAsIdentifier
            ],

            Identifier = context.Name.TextAsIdentifier,
            Type = type,

            InnerScope = new Scope { Identifier = Identifier.None, Parent = CTX.CurrentScope },

            IsExternal = context.External() is not null
        };

        // TODO: throw errors on improper usage of 'external'

        context.DefinedFunction = CTX.CurrentScope.DefineOrDiagnose(
            CTX, context.CalculateSourceSpan(), function);

        // If we have succeeded, create the LLVM function
        if (context.DefinedFunction is not null)
        {
            // TODO: mangle names here?
            function.LLVMFunction = Option.Some(
                CTX.Module.AddFunction(function.FullName, function.Type.GetLLVMType(CTX)));

            // Define all arguments as variables in the function's inner scope
            foreach(var ((name, argtype), syntax) in function.ArgumentNames
                .Zip(function.Type.Parameters)
                .Zip(context._Args))
            {
                function.InnerScope.DefineOrDiagnose(CTX, syntax.CalculateSourceSpan(), new Variable
                {
                    Type = argtype,
                    Identifier = name
                });
            }
        }

        return default;
    }
}