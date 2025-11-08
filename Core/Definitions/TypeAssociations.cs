namespace Re.C.Definitions;

public class TypeAssociations(RecContext ctx)
{
    public RecContext CTX { get; } = ctx;
    private readonly MultiDictionary<Types.Type, Scope> namedAssociations = [];
    private readonly MultiDictionary<Types.Type, Scope> unnamedAssociations = [];

    public void Add(Types.Type type, Scope scope)
    {
        namedAssociations.Add(type, scope);
    }

    public void AddUnnamed(Types.Type type, Scope scope)
    {
        unnamedAssociations.Add(type, scope);
    }

    public IEnumerable<Scope> GetAllInScope(Types.Type type, IReadOnlyCollection<Scope> imports)
    {
        return Enumerable.Concat(
            from scope in namedAssociations.GetValueOrDefault(type) ?? []
                where imports.Contains(scope)
                select scope,
            unnamedAssociations.GetValueOrDefault(type) ?? []
        );
    }

    public Result<Function, SearchFailure> Search(
        Types.Type type, Identifier ident, IReadOnlyCollection<Scope> imports)
    {
        return Scope.SearchInMany(GetAllInScope(type, imports), ident)
            .MapOk(static x => x.UnwrapAs<Function>());
    }

    public Function? SearchOrDiagnose(
        SourceSpan span, Types.Type type, Identifier ident, IReadOnlyCollection<Scope> imports)
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
