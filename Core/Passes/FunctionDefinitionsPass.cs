using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class FunctionDefinitionsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        if (context.DefinedFunction is null)
            return default;

        context.BoundStatements = [..
            from stmt in context.Body._Statements
            select CTX.Resolvers.Syntax.Visit(stmt)
        ];

        return default;
    }
}