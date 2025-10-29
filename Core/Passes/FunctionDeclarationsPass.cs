using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class FunctionDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override bool EnterAsBlocks => true;

    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        var span = context.CalculateSourceSpan();
        var selfType = context.fnSelfDefine() switch
        {
            RecParser.FnDefineSelfContext => CTX.Scopes.Current.AssociatedType.UnwrapNull(),
            RecParser.FnDefineSelfPtrContext => Types.Type.Pointer(CTX.Scopes.Current.AssociatedType.UnwrapNull()),
            
            _ => null
        };

        // Get the type of the function from its signature
        var type = new FunctionType
        {
            Parameters = [
                ..from arg in context._Args
                    select CTX.Resolvers.Type.Visit(arg.typename()),
                ..Option.Nonnull(selfType)
            ],

            Return = context.Ret is null
                ? CTX.BuiltinTypes.None
                : CTX.Resolvers.Type.Visit(context.Ret)
        };

        var argNames = (Identifier[])[
            ..from arg in context._Args
                select arg.Identifier().TextAsIdentifier,
            ..Option.If(selfType is not null, Identifier.Builtin.Self)
        ];

        // Define arguments in an anonymous inner scope
        var innerScope = new Scope 
        { 
            Identifier = Identifier.None, 
            Parent = CTX.Scopes.Current,
            CTX = CTX
        };

        var argInfo = argNames
            .Zip(type.Parameters)
            .Zip(context._Args);

        var argDefs = (Variable?[])[..
            from info in argInfo
                let name = info.First.First
                let argtype = info.First.Second
                let syntax = info.Second
                select innerScope.DefineOrDiagnose(syntax.CalculateSourceSpan(), new Variable
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

            IsExternal = context.External() is not null,
            HasReceiver = selfType is not null
        };

        context.DefinedFunction = CTX.Scopes.Current.DefineOrDiagnose(
            span, function);

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

        return default;
    }
}