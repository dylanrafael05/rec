using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;
using Antlr4.Runtime.Tree;

namespace Re.C.Passes;

public class FunctionDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override bool EnterAsBlocks => true;

    public override Unit VisitAsStatement([NotNull] RecParser.AsStatementContext context)
    {
        var span = context.CalculateSourceSpan();
        var typespan = context.typename().CalculateSourceSpan();
        var anytype = CTX.Resolvers.Type.Visit(context.typename());

        if(anytype is not NamedType type)
        {
            CTX.Diagnostics.AddError(
                typespan, Errors.InvalidAsBlockTarget(anytype));
            
            return Unit();
        }

        Scope scope;

        if(context.ModuleIdent is null)
        {
            if(CTX.CurrentSource != type.DefinitionLocation.Map(static x => x.Source))
            {
                CTX.Diagnostics.AddError(
                    typespan, Errors.UnnamedAsBlockInDifferentFile());
                
                return Unit();
            }

            scope = new Scope
            {
                Parent = CTX.Scopes.Current,
                Identifier = Identifier.None,
                CTX = CTX,
                DefinitionLocation = Option.Some(context.CalculateSourceSpan()),

                AssociatedType = type  
            };

            CTX.TypeAssociations.AddUnnamed(type, scope);
        }
        else
        {
            scope = CTX.Scopes.Current.DefineOrDiagnose(
                context.ModuleIdent.SourceSpan,
                new Scope
                {
                    Identifier = context.ModuleIdent.TextAsIdentifier,
                    CTX = CTX,
                    AssociatedType = type,
                    DefinitionLocation = Option.Some(context.CalculateSourceSpan()),
                })!;

            if(scope is null)
                return Unit();
            
            CTX.TypeAssociations.Add(type, scope);
        }

        context.Scope = scope;

        return base.VisitAsStatement(context);
    }

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

        var argSyntaxes = (IParseTree[])[
            ..context._Args,
            ..Option.Nonnull(context.fnSelfDefine())
        ];

        // Define arguments in an anonymous inner scope
        var innerScope = new Scope 
        { 
            Identifier = Identifier.None, 
            Parent = CTX.Scopes.Current,
            DefinitionLocation = Option.None,
            CTX = CTX
        };

        var argInfo = argNames
            .Zip(type.Parameters)
            .Zip(argSyntaxes);

        var argDefs = (Variable?[])[..
            from info in argInfo
                let name = info.First.First
                let argtype = info.First.Second
                let syntax = info.Second
                select innerScope.DefineOrDiagnose(syntax.CalculateSourceSpan(), new Variable
                {
                    Type = argtype,
                    Identifier = name,
                    DefinitionLocation = Option.Some(syntax.CalculateSourceSpan())
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
            HasReceiver = selfType is not null,
            
            DefinitionLocation = Option.Some(context.CalculateSourceSpan()),
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