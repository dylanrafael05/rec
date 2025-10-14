using Re.C.Vocabulary;

namespace Re.C.Syntax;

/// <summary>
/// The base class of all nodes of the bound syntax tree.
/// </summary>
public class BoundSyntax
{
    public required SourceSpan Span { get; init; }
}
