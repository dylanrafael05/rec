namespace Re.C.Vocabulary;

/// <summary>
/// An object which represents a single unit of compilable
/// code, given a name (typically the file the code is from).
/// </summary>
public record Source(string Name, string Content)
{
    public override string ToString()
        => $"Source '{Name}'";
}

/// <summary>
/// A location within a source, stored in index and (line:column) formats.
/// </summary>
public record struct SourceLocation(int Line, int Column, int Index)
{
    public static SourceLocation Min(SourceLocation lhs, SourceLocation rhs)
        => lhs.Index < rhs.Index ? lhs : rhs;
    public static SourceLocation Max(SourceLocation lhs, SourceLocation rhs)
        => lhs.Index > rhs.Index ? lhs : rhs;

    public override readonly string ToString()
        => $"{Line}:{Column}@{Index}";
}

/// <summary>
/// A span of locations within a source, as well as a reference
/// to the source the span is a part of.
/// </summary>
public record struct SourceSpan(Source Source, SourceLocation Start, SourceLocation End)
{
    public override readonly string ToString()
        => $"({Source}) {Start} to {End}";
    
    public static SourceSpan Combine(params ReadOnlySpan<SourceSpan> spans)
    {
        if (spans.Length == 0)
        {
            throw new InvalidOperationException($"SourceSpan.Combine requires at least one argument.");
        }

        var min = spans[0].Start;
        var max = spans[0].End;

        foreach (var span in spans)
        {
            min = SourceLocation.Min(min, span.Start);
            max = SourceLocation.Max(max, span.End);
        }

        return new(spans[0].Source, min, max);
    }
}