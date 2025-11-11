using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class FileUsagesPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitUseStatement([NotNull] RecParser.UseStatementContext context)
    {
        var scope = CTX.GlobalScope.DeepSearchOrDiagnose(
            [..from p in context.fullIdentifier()._Parts select p.SourceSpan],
            [..from p in context.fullIdentifier()._Parts select p.TextAsIdentifier]);

        if(scope is not null)
            CTX.ImportsBySource.Add(
                CTX.CurrentSource.UnwrapNull(), 
                scope.UnwrapAs<Scope>());

        return default;
    }
}
