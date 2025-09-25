using Antlr4.Runtime.Misc;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver(RecContext ctx) : RecBaseVisitor<BoundSyntax>
{
    private RecContext Context { get; } = ctx;
}