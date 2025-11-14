
namespace Re.C.Types;

public class ReferenceType : RecType
{
    public required RecType Referee { get; init; }

    public override bool Equals(RecType? other)
        => other is ReferenceType t
        && t.Referee.Equals(Referee);
    public override int GetHashCode()
        => HashCode.Combine(Referee);

    public override string Name => $"&{Referee.Name}";
    public override string FullName => $"&{Referee.FullName}";

    public override bool IsDereferencable => true;
    public override Option<RecType> Deref => Option.Some(Referee);

    public override void PropogateVisitor<V>(V visitor)
        => visitor.Visit(Referee);
}
