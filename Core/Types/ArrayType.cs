
namespace Re.C.Types;

public class ArrayType : RecType
{
    public required RecType Elem { get; init; }
    public override Option<RecType> Element => Option.Some(Elem);

    public override bool Equals(RecType? other)
        => other is ArrayType t
        && t.Elem.Equals(Elem);
    public override int GetHashCode()
        => HashCode.Combine(Elem);

    public override string Name => $"[{Elem.Name}]";
    public override string FullName => $"[{Elem.FullName}]";

    public override void PropogateVisitor<V>(V visitor)
        => visitor.Visit(Elem);

    public override RecType ApplySubstitutions(TypeSubstitutions substitutions)
    {
        var elem = Elem.ApplySubstitutions(substitutions);

        if(!object.ReferenceEquals(elem, Elem))
            return new ArrayType { Elem = elem };

        return this;
    }
}
