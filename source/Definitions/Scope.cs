namespace Re.C.Definitions;

public class Scope : DefinitionBase
{
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
        return def;
    }
    
    /// <summary>
    /// Define the provided definition within this scope,
    /// returning the definition if sucessful and reporting
    /// a diagnostic if unsuccessful.
    /// </summary>
    public Definition? DefineOrDiagnose<Definition>(RecContext ctx, SourceSpan span, Definition def)
        where Definition : class, IDefinition
    {
        if (Definitions.ContainsKey(def.Identifier))
        {
            ctx.Diagnostics.AddError(
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
    public IDefinition? Search(Identifier identifier, IReadOnlyList<Scope>? importedScopes = null)
    {
        // Search within this scope
        if (Definitions.TryGetValue(identifier, out var def))
        {
            return def;
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
                def = null;

                foreach (var scope in importedScopes)
                {
                    if (def is not null)
                    {
                        // NOTE: importedScopes is not propogated
                        // because we are already iterating the
                        // imported scopes here.
                        def = scope.Search(identifier, null);
                    }
                    else
                    {
                        // TODO: handle ambiguity //
                        return null;
                    }
                }

                if (def is not null)
                {
                    return def;
                }
            }

            // Otherwise, we have reached the "end of the line"
            // and the lookup is unsucessful
            return null;
        }

        // Otherwise, recurse and search in the parent scope.
        return Parent.Search(identifier, importedScopes);
    }
}