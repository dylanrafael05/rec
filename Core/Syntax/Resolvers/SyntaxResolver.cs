using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver(RecContext CTX) : RecBaseVisitor<BoundSyntax>
{
    protected override BoundSyntax AggregateResult(BoundSyntax aggregate, BoundSyntax nextResult)
    {
        if (aggregate is not null && nextResult is not null)
            throw Panic("Cannot aggregate multiple syntaxes!");

        if (aggregate is not null)
            return aggregate;

        return nextResult!;
    }
}