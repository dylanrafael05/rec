using Antlr4.Runtime.Tree;
using Re.C.Antlr;
using Re.C.Visitor;
using Re.C.Vocabulary;

namespace Re.C.Syntax;

/// <summary>
/// The base class of all nodes of the bound syntax tree.
/// </summary>
public abstract class BoundSyntax : IVisitable<BoundSyntax>
{
    public required SourceSpan Span { get; init; }

    public static ErrorExpression ErrorExpression(SourceSpan span, RecContext ctx)
        => new() { Span = span, Type = ctx.BuiltinTypes.Error };
    public static ErrorExpression ErrorExpression(IParseTree tree, RecContext ctx)
        => ErrorExpression(tree.CalculateSourceSpan(), ctx);
    public static ErrorStatement ErrorStatement(SourceSpan span, RecContext ctx)
        => new() { Span = span };
    public static ErrorStatement ErrorStatement(IParseTree tree, RecContext ctx)
        => ErrorStatement(tree.CalculateSourceSpan(), ctx);

    public virtual void PropogateVisitor<V>(V visitor) 
        where V : IVisitor<BoundSyntax>, allows ref struct
    {}
}
