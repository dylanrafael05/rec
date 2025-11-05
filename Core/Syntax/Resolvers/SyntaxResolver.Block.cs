using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    /// <summary>
    /// Convert a syntactical block into a sequence of
    /// syntactical statements, compiled within a new
    /// anonymous scope.
    /// </summary>
    public override BoundSyntax VisitBlock([NotNull] RecParser.BlockContext context)
    {
        var scope = new Scope
        {
            Identifier = Identifier.None,
            Parent = CTX.Scopes.Current,
            DefinitionLocation = Option.Some(context.CalculateSourceSpan()),
            CTX = CTX,
        };

        CTX.Scopes.Enter(scope);
        var syntax = (BoundSyntax[])[..
            from s in context._Statements
            select Visit(s)
        ];
        CTX.Scopes.Exit();

        return new Block
        {
            Span = context.CalculateSourceSpan(),
            Syntax = syntax,
            Scope = scope
        };
    }
}