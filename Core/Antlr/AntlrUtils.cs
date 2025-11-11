using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

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

                if (self.StartIndex is -1)
                    throw Panic("Token does not implement start index");

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
        private IToken LeftmostToken()
        {
            if (self is ITerminalNode term)
                return term.Symbol;

            return self.GetChild(0).LeftmostToken();
        }

        private IToken RightmostToken()
        {
            if (self is ITerminalNode term)
                return term.Symbol;

            return self.GetChild(self.ChildCount - 1).RightmostToken();
        }

        public SourceSpan CalculateSourceSpan()
        {
            if (self is ITerminalNode term)
                return term.Symbol.SourceSpan;

            var first = self.LeftmostToken().SourceSpan;
            var last = self.RightmostToken().SourceSpan;

            return SourceSpan.Combine(first, last);
        }
    }
}