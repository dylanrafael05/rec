namespace Re.C.Types;

public class FunctionType : RecType
{
    public required Seq<RecType> Parameters { get; init; }
    public required RecType Return { get; init; }

    public override bool Equals(RecType? other)
        => other is FunctionType fn
        && fn.Parameters == Parameters
        && fn.Return == Return;
    public override int GetHashCode()
        => HashCode.Combine(typeof(FunctionType), Parameters, Return);

    private string GetName(Func<RecType, string> stringifier)
    {
        var result = "fn("
            + string.Join(", ", from p in Parameters select stringifier(p))
            + ")";

        if (Return is not null)
            result += " " + stringifier(Return);

        return result;
    }

    public override string Name => GetName(t => t.Name);
    public override string FullName => GetName(t => t.FullName);
    public override bool IsSized => false;

    public override void PropogateVisitor<V>(V visitor)
    {
        visitor.Visit(Return);
        visitor.VisitMany(Parameters);
    }
    
    public override RecType ApplySubstitutions(TypeSubstitutions substitutions)
    {
        var ret = Return.ApplySubstitutions(substitutions);
        var parameters = Parameters.ThinMap(ReferenceEquals, substitutions, (s, t) => t.ApplySubstitutions(s));

        if(!ReferenceEquals(ret, Return) || !parameters.ReferenceEquals(Parameters))
            return new FunctionType { Return = ret, Parameters = parameters };

        return this;
    }
}
