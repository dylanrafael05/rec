using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitProgram([NotNull] RecParser.ProgramContext context)
    {
        return new GroupSyntax
        {
            Span = context.CalculateSourceSpan(),
            Subsyntax = [.. context.children.Select(Visit)]
        };
    }
}