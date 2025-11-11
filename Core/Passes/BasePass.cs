using Antlr4.Runtime.Misc;

namespace Re.C.Passes;

/// <summary>
/// The base class for all parse-tree-visitors in the Rec 
/// compilation process.
/// 
/// Implements any common behaviours.
/// </summary>
public class BasePass(RecContext ctx) : RecBaseVisitor<Unit>
{
    public RecContext CTX { get; } = ctx;
    public virtual bool EnterAsBlocks => false;

    public override Unit VisitModStatement([NotNull] RecParser.ModStatementContext context)
    {
        CTX.Scopes.Enter(context.Scope.UnwrapNull());
        VisitChildren(context);
        CTX.Scopes.Exit();

        return default;
    }

    public override Unit VisitAsStatement([NotNull] RecParser.AsStatementContext context)
    {
        if(EnterAsBlocks)
        {
            CTX.Scopes.Enter(context.Scope.UnwrapNull());
            VisitChildren(context);
            CTX.Scopes.Exit();
        }

        return default;
    }
}
