using System.Buffers;
using System.Text;
using Pastel;
using Re.C.Visitor;
using Re.C.Vocabulary;

namespace Re.C.CLI;

public static class DiagnosticOutput
{
    public static string Format(this SourceSpan span)
        => $"[{span.Source.Name}:{span.Start.Line}:{span.Start.Column} to {span.End.Line}:{span.End.Column}]";

    public static string Format(this Diagnostic diagnostic)
    {
        var builder = new StringBuilder();

        var source = diagnostic.Span.Source;
        var startIndex = diagnostic.Span.Start.Index;
        var startColumn = diagnostic.Span.Start.Column;
        var lineStartIndex = startIndex - startColumn;

        var content = source.Content.AsSpan();
        var fromStart = content[lineStartIndex..];

        var endIndex = content.IndexOfAny('\n', '\r');
        var trimIndex = content.IndexOfAnyExcept(' ', '\t');

        var highlightedSegment = content[trimIndex..endIndex];

        builder
            .Append($"{"Error".Pastel(ConsoleColor.Red)} at {diagnostic.Span}:").AppendLine()
            .Append($"\t{diagnostic.Message.Pastel(ConsoleColor.Red)}").AppendLine()
            .Append(highlightedSegment.Pastel(ConsoleColor.Gray)).AppendLine();

        for (var i = 0; i < highlightedSegment.Length; i++)
            builder.Append((i > startColumn - trimIndex) switch
            {
                true => ' ',
                false => '^'
            });

        builder.AppendLine();

        return builder.ToString();
    }
}