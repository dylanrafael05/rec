using Antlr4.Runtime;

namespace Re.C.Antlr;

public class DiagnosticLexerListener(RecContext ctx) : IAntlrErrorListener<int>
{
    public void SyntaxError(
        TextWriter output,
        IRecognizer recognizer,
        int offendingSymbol,
        int line, int charPositionInLine,
        string msg,
        RecognitionException e)
    {
        var lexer = recognizer.UnwrapAs<RecLexer>();
        var source = lexer.Source;
        var loc = new SourceLocation(line, charPositionInLine, lexer.CharIndex);
        var span = new SourceSpan(source, loc, loc);

        ctx.Diagnostics.AddError(span, msg);
    }
}
