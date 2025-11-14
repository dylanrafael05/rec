namespace Re.C.Types;

public class PointerType : RecType
{
    public required RecType Pointee { get; init; }

    public override bool Equals(RecType? other)
        => other is PointerType t
        && t.Pointee.Equals(Pointee);
    public override int GetHashCode()
        => HashCode.Combine(Pointee);

    public override string Name => $"*{Pointee.Name}";
    public override string FullName => $"*{Pointee.FullName}";
    
    public override bool IsDereferencable => true;
    public override Option<RecType> Deref => Option.Some(Pointee);

    public override void PropogateVisitor<V>(V visitor)
        => visitor.Visit(Pointee);
}
