using System.Buffers;
using System.Text;
using Pastel;
using Re.C.Visitor;
using Re.C.Vocabulary;

namespace Re.C.CLI;

public static class DiagnosticOutput
{
    public static string Format(this SourceSpan span)
        => $"[{span.Source?.Name}:{span.Start.Line}:{span.Start.Column+1} to {span.End.Line}:{span.End.Column+1}]";

    public static string Format(this Diagnostic diagnostic)
    {
        var builder = new StringBuilder();

        var source = diagnostic.Span.Source;
        var startIndex = diagnostic.Span.Start.Index;
        var startColumn = diagnostic.Span.Start.Column;
        var lineStartIndex = startIndex - startColumn;
        var indexLength = diagnostic.Span.End.Index - startIndex;

        var content = source.UnwrapNull().Content.AsSpan();
        var fromStart = content[lineStartIndex..];

        var endIndex = fromStart.IndexOfAny('\n', '\r');
        var trimIndex = fromStart.IndexOfAnyExcept(' ', '\t');

        var highlightedSegment = fromStart[trimIndex..(endIndex == -1 ? ^0 : endIndex)];

        var (diagKind, diagColor) = diagnostic.Kind switch
        {
            DiagnosticKind.Error => ("Error", ConsoleColor.Red),
            DiagnosticKind.Warning => ("Warning", ConsoleColor.Yellow),
            DiagnosticKind.Info => ("Info", ConsoleColor.DarkCyan),

            _ => throw ErrorHandling.Unreachable
        };

        builder
            .Append($"{diagKind.Pastel(diagColor)} at {diagnostic.Span.Format()}: ")
            .Append($"{diagnostic.Message.Pastel(diagColor)}").AppendLine()
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