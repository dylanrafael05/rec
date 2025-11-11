using Antlr4.Runtime.Misc;
using Re.C.Syntax;

namespace Re.C.Passes;

public class FunctionDefinitionsPass(RecContext ctx) : BasePass(ctx)
{
    public override bool EnterAsBlocks => true;
    
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        if (context.DefinedFunction is null || context.DefinedFunction.IsExternal)
            return default;

        CTX.Functions.Enter(context.DefinedFunction);
        CTX.Scopes.Enter(CTX.Functions.Current!.InnerScope);

        context.BoundBody = CTX.Resolvers.Syntax.Visit(context.Body).UnwrapAs<Block>();
        context.DefinedFunction.Body = Option.Some(context.BoundBody);

        CTX.Scopes.Exit();
        CTX.Functions.Exit();

        return default;
    }
}