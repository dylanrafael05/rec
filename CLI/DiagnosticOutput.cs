using System.Buffers;
using System.Text;
using Pastel;
using Re.C.Visitor;
using Re.C.Vocabulary;

namespace Re.C.CLI;

public static class DiagnosticOutput
{
    public static string Format(this SourceSpan span)
        => $"[{span.Source.Name}:{span.Start.Line}:{span.Start.Column+1} to {span.End.Line}:{span.End.Column+1}]";

    public static string Format(this Diagnostic diagnostic)
    {
        var builder = new StringBuilder();

        var source = diagnostic.Span.Source;
        var startIndex = diagnostic.Span.Start.Index;
        var startColumn = diagnostic.Span.Start.Column;
        var lineStartIndex = startIndex - startColumn;
        var indexLength = diagnostic.Span.End.Index - startIndex;

        var content = source.Content.AsSpan();
        var fromStart = content[lineStartIndex..];

        var endIndex = fromStart.IndexOfAny('\n', '\r');
        var trimIndex = fromStart.IndexOfAnyExcept(' ', '\t');

        var highlightedSegment = fromStart[trimIndex..endIndex];

        builder
            .Append($"{"Error".Pastel(ConsoleColor.Red)} at {diagnostic.Span.Format()}: ")
            .Append($"{diagnostic.Message.Pastel(ConsoleColor.Red)}").AppendLine()
            .Append("  |  ").Append(highlightedSegment.Pastel(ConsoleColor.DarkGray)).AppendLine()
            .Append("     ");

        for (var i = 0; i < highlightedSegment.Length; i++)
            builder.Append((i < startColumn - trimIndex || i > startColumn - trimIndex + indexLength) switch
            {
                true => ' ',
                false => '^'
            });

        builder.AppendLine();

        return builder.ToString();
    }
}