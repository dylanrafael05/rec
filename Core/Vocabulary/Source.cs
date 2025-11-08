namespace Re.C.Vocabulary;

/// <summary>
/// An object which represents a single unit of compilable
/// code, given a name (typically the file the code is from).
/// </summary>
public class Source(string name, string content)
{
    public string Name { get; } = name;
    public string Content { get; } = content;

    public override string ToString()
        => $"Source '{Name}'";

    public static Source Builtin { get; } = new("<built-in>", "");
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
    public static SourceSpan Generated(Source source) 
        => new(source, new(-1, -1, -1), default);
    public static SourceSpan Builtin => new(Source.Builtin, default, default);

    public override readonly string ToString()
    {
        if(Source == Source.Builtin)
            return "<builtin>";

        if(Start.Column == -1)
            return $"({Source.Name}) <generated>";

        return $"({Source.Name}) {Start} to {End}";
    }
    
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