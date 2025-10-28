using OneOf;

namespace Re.C.Definitions;

/// <summary>
/// A type representing a failure to find a value within
/// some scope.
/// </summary>
[DiscriminatedUnion]
public partial record struct SearchFailure
{
    public static class Cases
    {
        public record struct NotFound;
        public record struct Ambiguous(List<IDefinition> Values);
    }
}

public class Scope : DefinitionBase
{
    public required RecContext CTX { get; init; }
    public Types.Type? AssociatedType { get; init; }
    public Dictionary<Identifier, IDefinition> Definitions { get; } = [];

    /// <summary>
    /// Define the provided definition within this scope,
    /// returning the definition if sucessful and null if
    /// failed.
    /// </summary>
    public Definition? Define<Definition>(Definition def)
        where Definition : class, IDefinition
    {
        if (Definitions.ContainsKey(def.Identifier))
            return null;

        Definitions[def.Identifier] = def;

        def.Parent = this;
        def.IsLinked = true;

        return def;
    }

    /// <summary>
    /// Define the provided definition within this scope,
    /// returning the definition if sucessful and reporting
    /// a diagnostic if unsuccessful.
    /// </summary>
    public Definition? DefineOrDiagnose<Definition>(SourceSpan span, Definition def)
        where Definition : class, IDefinition
    {
        if (Definitions.ContainsKey(def.Identifier))
        {
            CTX.Diagnostics.AddError(
                span, Errors.Redefinition(def.Identifier, this));

            return null;
        }

        Definitions[def.Identifier] = def;
        return def;
    }

    /// <summary>
    /// Search within this scope for a definition that matches
    /// the provided identifier.
    /// </summary>
    public Result<IDefinition, SearchFailure> Search(Identifier identifier, IReadOnlyList<Scope>? importedScopes = null)
    {
        // Search within this scope
        if (Definitions.TryGetValue(identifier, out var def))
        {
            return Result.Ok(def);
        }

        // Otherwise, check in the parent scope.
        // If we have no parent scope, there is no
        // found value (or we perform imported lookup).
        if (Parent is null)
        {
            // If we are performing internal lookup,
            // search imported scopes
            if (importedScopes is not null)
            {
                return SearchInMany(importedScopes, identifier);
            }

            // Otherwise, we have reached the "end of the line"
            // and the lookup is unsucessful
            return Result.Err(SearchFailure.NotFound);
        }

        // Otherwise, recurse and search in the parent scope.
        return Parent.Search(identifier, importedScopes);
    }

    /// <summary>
    /// The same as Search, but emits an error when fails.
    /// </summary>
    public IDefinition? SearchOrDiagnose(
        SourceSpan span,
        Identifier identifier,
        IReadOnlyList<Scope>? importedScopes = null)
    {
        var def = Search(identifier, importedScopes);

        if (def.IsErr(out var err) && err.IsNotFound)
        {
            var msg = (this == CTX.Scopes.Current) switch
            {
                true => Errors.UndefinedInCurrentScope(identifier),
                false => Errors.UndefinedInGivenScope(identifier, this)
            };

            CTX.Diagnostics.AddError(span, msg);
        }
        else if (def.IsErr(out err) && err.IsAmbiguous(out var ambiguous))
        {
            // TODO: report ambiguity here
        }

        return def.Or(null);
    }

    /// <summary>
    /// Search within a list of scopes for a definition
    /// </summary>
    public static Result<IDefinition, SearchFailure> SearchInMany<Scopes>(
        Scopes scopes, Identifier identifier)
        where Scopes : IEnumerable<Scope>
    {
        var results = new List<IDefinition>{};
        
        foreach(var scope in scopes)
        {
            if(scope.Search(identifier).IsOk(out var value))
                results.Add(value);
        }

        return results switch
        {
            []              => Result.Err(SearchFailure.NotFound),
            [var single]    => Result.Ok(single),
            var rest        => Result.Err(SearchFailure.Ambiguous(rest)),
        };
    }
}