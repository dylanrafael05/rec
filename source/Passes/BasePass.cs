using Antlr4.Runtime.Misc;
using Re.C.Definitions;
using Re.C.Vocabulary;

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

    public override Unit VisitModStatement([NotNull] RecParser.ModStatementContext context)
    {
        CTX.EnterScope(context.Scope.UnwrapNull());
        VisitChildren(context);
        CTX.ExitScope();

        return default;
    }
}
