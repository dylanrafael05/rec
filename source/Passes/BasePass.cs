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
    public Stack<Scope> ScopeStack { get; } = [];

    public override Unit VisitModStatement([NotNull] RecParser.ModStatementContext context)
    {
        ScopeStack.Push(CTX.CurrentScope);
        CTX.CurrentScope = context.Scope.UnwrapNull();

        VisitChildren(context);

        CTX.CurrentScope = ScopeStack.Pop();
        return default;
    }
}
