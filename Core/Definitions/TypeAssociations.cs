namespace Re.C.Definitions;

public class TypeAssociations
{
    private readonly MultiDictionary<Types.Type, Scope> values = [];

    public void Add(Types.Type type, Scope scope)
    {
        values.Add(type, scope);
    }

    public IEnumerable<Scope> GetAllInScope(Types.Type type, IReadOnlyList<Scope> imports)
    {
        return from scope in values[type] 
            where imports.Contains(scope)
            select scope;
    }

    public Result<Function, SearchFailure> Search(
        Types.Type type, Identifier ident, IReadOnlyList<Scope> imports)
    {
        return Scope.SearchInMany(GetAllInScope(type, imports), ident)
            .MapOk(static x => x.UnwrapAs<Function>());
    }

    public Function? SearchOrDiagnose(
        SourceSpan span, Types.Type type, Identifier ident, IReadOnlyList<Scope> imports)
    {
        var ctx = imports[0].CTX;
        var lookup = Search(type, ident, imports);

        if(lookup.IsOk(out var result))
            return result;

        lookup.IsErr(out var err);

        if(err.IsNotFound)
        {
            ctx.Diagnostics.AddError(
                span, Errors.UndefinedInCurrentScope(ident));
        }
        else
        {
            err.UnwrapAsAmbiguous(out var values);
            ctx.Diagnostics.AddError(
                span, Errors.AmbiguousIdentifier(ident, values));
        }

        return null;
    }
}
