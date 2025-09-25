namespace Re.C.Vocabulary;

public record Source(string Code);

public record struct SourceLocation(int Line, int Column, int Index)
{
    public static SourceLocation Min(SourceLocation lhs, SourceLocation rhs)
        => lhs.Index < rhs.Index ? lhs : rhs;
    public static SourceLocation Max(SourceLocation lhs, SourceLocation rhs)
        => lhs.Index > rhs.Index ? lhs : rhs;
}

public record struct SourceSpan(Source Source, SourceLocation Start, SourceLocation End)
{
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