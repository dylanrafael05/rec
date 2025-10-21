using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Passes;

public class FunctionDefinitionsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        if (context.DefinedFunction is null || context.DefinedFunction.IsExternal)
            return default;

        CTX.CurrentFunction = context.DefinedFunction;
        CTX.EnterScope(CTX.CurrentFunction.InnerScope);

        context.BoundBody = CTX.Resolvers.Syntax.Visit(context.Body).UnwrapAs<Block>();
        context.DefinedFunction.Body = Option.Some(context.BoundBody);

        Console.WriteLine(context.BoundBody is null);

        Console.WriteLine(
            "success! syntax tree = \n" +
            context.BoundBody.UnwrapAs<BoundSyntax>().PrettyPrint());

        CTX.ExitScope();
        CTX.CurrentFunction = null;

        return default;
    }
}