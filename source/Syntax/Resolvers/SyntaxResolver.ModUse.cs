using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitModStatement([NotNull] RecParser.ModStatementContext context)
    {
        // Get the scope referred to by this mod statement
        //
        // Note that the scope may not exist yet, and as such it must be
        // defined on-the-fly while searching for it
        //
        // Also of note is that the search always begins at the current scope
        // level, and never accounts for imported scopes
        var scope = Context.CurrentScope;

        foreach (var partToken in context.ModuleIdent._Parts)
        {
            var part = Identifier.Name(partToken.Text);

            if (scope.Definitions.TryGetValue(part, out var subscopeDef))
            {
                if (subscopeDef is Scope subscope)
                {
                    scope = subscope;
                }
                else
                {
                    Context.Diagnostics.AddError(
                        partToken.SourceSpan,
                        Errors.Redefinition(part, scope));

                    scope = Context.GlobalScope;
                    break;
                }
            }
            else
            {
                scope = scope.Define(new Scope { Identifier = part })!;
            }
        }

        // Visit subsyntax under the new module
        var previousScope = Context.CurrentScope;

        Context.CurrentScope = scope;
        var subsyntax = (List<BoundSyntax>)[.. context._Substatements.Select(Visit)];
        Context.CurrentScope = previousScope;

        return new ModSyntax
        {
            Span = context.CalculateSourceSpan(),
            Subsyntax = subsyntax,
            Scope = scope
        };
    }

    public override BoundSyntax VisitUseStatement([NotNull] RecParser.UseStatementContext context)
    {
        var scope = IdentifierResolution.Resolve(Context, context.Ident);

        if (scope is Scope s)
            Context.CurrentImports.Add(s);

        return new UseSyntax
        {
            Span = context.CalculateSourceSpan(),
            Scope = scope as Scope ?? Context.GlobalScope
        };
    }
}