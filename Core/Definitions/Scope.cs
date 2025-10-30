using Re.C.Types;

namespace Re.C.Definitions;

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
        var result = Define(def);

        if (result is null)
        {
            CTX.Diagnostics.AddError(
                span, Errors.Redefinition(def.Identifier, this));

            return null;
        }

        return result;
    }

    /// <summary>
    /// Search within this scope for a definition that matches
    /// the provided identifier.
    /// </summary>
    public Result<IDefinition, SearchFailure> Search(Identifier identifier, IReadOnlyCollection<Scope>? importedScopes = null)
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
            if (importedScopes is not null && importedScopes.Count != 0)
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
    /// Emit a diagnostic for the given SearchFailure
    /// </summary>
    private void Diagnose(SourceSpan span, Identifier identifier, SearchFailure err)
    {
        if (err.IsNotFound)
        {
            var msg = (this == CTX.Scopes.Current) switch
            {
                true => Errors.UndefinedInCurrentScope(identifier),
                false => Errors.UndefinedInGivenScope(identifier, this)
            };

            CTX.Diagnostics.AddError(span, msg);
        }
        else if (err.IsAmbiguous(out var ambiguous))
        {
            CTX.Diagnostics.AddError(
                span, Errors.AmbiguousIdentifier(identifier, ambiguous));
        }
        else throw Unreachable;
    }

    /// <summary>
    /// The same as Search, but emits an error when fails.
    /// </summary>
    public IDefinition? SearchOrDiagnose(
        SourceSpan span,
        Identifier identifier,
        IReadOnlyCollection<Scope>? importedScopes = null)
    {
        var def = Search(identifier, importedScopes);

        if (def.IsErr(out var err))
            Diagnose(span, identifier, err);

        return def.Or(null);
    }
    
    /// <summary>
    /// Search deep within this scope; looking through subdefinitions recursively
    /// </summary>
    public Result<IDefinition, DeepSearchFailure> DeepSearch(IReadOnlyList<Identifier> parts)
    {
        var result = this as IDefinition;
        var imports = CTX.CurrentImports;

        foreach(var (part, index) in parts.Indexed)
        {
            Result<IDefinition, SearchFailure> subresult;
            if(result is Scope scope)
            {
                subresult = scope.Search(part, imports);
            }
            else if(result is NamedType type)
            {
                subresult = SearchInMany(
                    CTX.TypeAssociations.GetAllInScope(type, CTX.CurrentImports),
                    part);
            }
            else return Result.Err(DeepSearchFailure.NotAScope(result, index));

            if(subresult.IsErr(out var err))
                return Result.Err(DeepSearchFailure.Search(err, index));

            subresult.UnwrapAsOk(out result);
            imports = null;
        }

        return Result.Ok(result);
    }

    /// <summary>
    /// Search deep within this scope; looking through subdefinitions recursively,
    /// emitting a diagnostic and returning null on failure
    /// </summary>
    public IDefinition? DeepSearchOrDiagnose(IReadOnlyList<SourceSpan> partSpans, IReadOnlyList<Identifier> parts)
    {
        var result = DeepSearch(parts);

        if(result.IsErr(out var err))
        {
            if(err.IsNotAScope(out _, out var index))
            {
                CTX.Diagnostics.AddError(
                    partSpans[index], Errors.InvalidScopeResolutionTarget());
            }
            else if(err.IsSearch(out var inner, out index))
            {
                Diagnose(partSpans[index], parts[index], inner);
            }
            else throw Unreachable;

            return null;
        }

        return result.UnwrapAsOk().Value;
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