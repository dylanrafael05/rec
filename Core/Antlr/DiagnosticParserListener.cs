using Antlr4.Runtime;

namespace Re.C.Antlr;

public class DiagnosticParserListener(RecContext ctx) : IAntlrErrorListener<IToken>
{
    public void SyntaxError(
        TextWriter output,
        IRecognizer recognizer,
        IToken offendingSymbol,
        int line, int charPositionInLine,
        string msg,
        RecognitionException e)
    {
        var span = offendingSymbol.SourceSpan;
        ctx.Diagnostics.AddError(span, msg);
    }
}
