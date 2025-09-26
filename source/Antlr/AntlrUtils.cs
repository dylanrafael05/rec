using Antlr4.Runtime;
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
                var reclexer = self.TokenSource as RecLexer
                    ?? throw new InvalidCastException();

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

            var result = (SourceSpan?)default;

            for (var i = 0; i < self.ChildCount; i++)
            {
                var child = self.GetChild(i);
                var subresult = child.CalculateSourceSpan();

                if (result is SourceSpan res)
                {
                    result = SourceSpan.Combine(subresult, res);
                }
                else
                {
                    result = subresult;
                }
            }

            return result!.Value;
        }
    }
}