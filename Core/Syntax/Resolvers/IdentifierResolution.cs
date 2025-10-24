using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Vocabulary;

namespace Re.C.Syntax.Resolvers;

/// <summary>
/// Helper class for resolving identifiers from the syntax tree.
/// </summary>
public static class IdentifierResolution
{
    /// <summary>
    /// Resolve a single identifier in the provided scope.
    /// Returns null and adds an appropriate diagnostic if
    /// resolution fails.
    /// </summary>
    public static IDefinition? ResolveOne(RecContext ctx, SourceSpan span, Identifier ident, IDefinition? scope = null)
    {
        var scopeToSearchAsDef = scope ?? ctx.CurrentScope;
        var imports = scope is null ? ctx.CurrentImports : null;

        if (scopeToSearchAsDef is not Scope scopeToSearch)
        {
            ctx.Diagnostics.AddError(span, Errors.InvalidScopeResolutionTarget());
            return null;
        }

        var definition = scopeToSearch.Search(ident, imports);

        if (definition is null)
        {
            var message = scope is null
                ? Errors.UndefinedInCurrentScope(ident)
                : Errors.UndefinedInGivenScope(ident, scope);

            ctx.Diagnostics.AddError(span, message);
        }

        return definition;
    }

    /// <summary>
    /// Resolve the entirety of a SimpleScopedIdentifier.
    /// </summary>
    public static IDefinition? Resolve(RecContext ctx, RecParser.FullIdentifierContext identifier)
    {
        var def = null as IDefinition;

        foreach (var part in identifier._Parts)
        {
            def = ResolveOne(ctx, part.SourceSpan, Identifier.Name(part.Text), def);

            if (def is null)
                break;
        }

        return def;
    }
}
