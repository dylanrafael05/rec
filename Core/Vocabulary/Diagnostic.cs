using System.Collections;

namespace Re.C.Vocabulary;

/// <summary>
/// The kind of diagnostic reported.
/// </summary>
public enum DiagnosticKind
{
    Error,
    Warning,
    Info
}

/// <summary>
/// A single diagnostic reported by the compiler. Diagnostics
/// are intended to display information only about the user's
/// code, and as such should not be used to debug the compiler's
/// internal state.
/// 
/// Complete with all information needed to be displayed to the
/// user in a readable format.
/// </summary>
public record struct Diagnostic(
    DiagnosticKind Kind,
    SourceSpan Span,
    string Message);

/// <summary>
/// A collection of diagnostics, with helper methods
/// for easily adding new diagnostics.
/// </summary>
public class DiagnosticBag : IReadOnlyCollection<Diagnostic>
{
    private readonly List<Diagnostic> diagnostics = [];
    private readonly HashSet<Source> sourcesWithError = [];

    public IReadOnlyList<Diagnostic> Diagnostics => diagnostics;

    public int Count => diagnostics.Count;
    public void Add(Diagnostic diagnostic)
    {
        diagnostics.Add(diagnostic);

        if(diagnostic.Kind is DiagnosticKind.Error)
            sourcesWithError.Add(diagnostic.Span.Source.UnwrapNull());
    }

    public void AddInfo(SourceSpan span, string message)
        => Add(new(DiagnosticKind.Info, span, message));
    public void AddWarning(SourceSpan span, string message)
        => Add(new(DiagnosticKind.Warning, span, message));
    public void AddError(SourceSpan span, string message)
        => Add(new(DiagnosticKind.Error, span, message));

    public bool HasErrors(Source source)
        => sourcesWithError.Contains(source);
    public bool AnyErrors
        => sourcesWithError.Count > 0;

    public IEnumerator<Diagnostic> GetEnumerator()
        => diagnostics.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}