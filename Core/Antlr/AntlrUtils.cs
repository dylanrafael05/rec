using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Re.C.Vocabulary;

namespace Re.C.Antlr;

public static class AntlrUtils
{
    extension(IToken self)
    {
        public SourceSpan SourceSpan
        {
            get
            {
                var reclexer = self.TokenSource.UnwrapAs<RecLexer>();

                return new(
                    reclexer.Source,
                    new(self.Line, self.Column, self.StartIndex),
                    new(self.Line, self.Column + (self.StopIndex - self.StartIndex), self.StopIndex)
                );
            }
        }

        public Identifier TextAsIdentifier
            => Identifier.Name(self.Text);
    }

    extension(ITerminalNode self)
    {
        public Identifier TextAsIdentifier
            => self.Symbol.TextAsIdentifier;
    }

    extension(IParseTree self)
    {
        public SourceSpan CalculateSourceSpan()
        {
            if (self is ITerminalNode term)
                return term.Symbol.SourceSpan;

            var first = self.GetChild(0).CalculateSourceSpan();
            var last = self.GetChild(self.ChildCount - 1).CalculateSourceSpan();

            return SourceSpan.Combine(first, last);
        }
    }
}