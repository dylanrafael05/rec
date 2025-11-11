using Re.C.Types;

namespace Re.C.Definitions;

public class TypeAssociations(RecContext ctx)
{
    public RecContext CTX { get; } = ctx;
    private readonly MultiDictionary<RecType, Scope> namedAssociations = [];
    private readonly MultiDictionary<RecType, Scope> unnamedAssociations = [];

    public void Add(RecType type, Scope scope)
    {
        namedAssociations.Add(type, scope);
    }

    public void AddUnnamed(RecType type, Scope scope)
    {
        unnamedAssociations.Add(type, scope);
    }

    public IEnumerable<Scope> GetAllInScope(RecType type, IReadOnlyCollection<Scope> imports)
    {
        return Enumerable.Concat(
            from scope in namedAssociations.GetValueOrDefault(type) ?? []
                where imports.Contains(scope)
                select scope,
            unnamedAssociations.GetValueOrDefault(type) ?? []
        );
    }

    public Result<Function, SearchFailure> Search(
        RecType type, Identifier ident, IReadOnlyCollection<Scope> imports)
    {
        return Scope.SearchInMany(GetAllInScope(type, imports), ident)
            .MapOk(static x => x.UnwrapAs<Function>());
    }

    public Function? SearchOrDiagnose(
        SourceSpan span, RecType type, Identifier ident, IReadOnlyCollection<Scope> imports)
    {
        var lookup = Search(type, ident, imports);

        if(lookup.IsOk(out var result))
            return result;

        lookup.IsErr(out var err);

        if(err.IsNotFound)
        {
            CTX.Diagnostics.AddError(
                span, Errors.UndefinedInCurrentScope(ident));
        }
        else
        {
            err.UnwrapAsAmbiguous(out var values);
            CTX.Diagnostics.AddError(
                span, Errors.AmbiguousIdentifier(ident, values));
        }

        return null;
    }
}
