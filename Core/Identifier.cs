namespace Re.C;

/// <summary>
/// A wrapper type representing a unique identifier.
/// Can either be a source-referencable name with optional associated type,
/// or a compiler-internal numeric ID.
/// </summary>
public readonly record struct Identifier(
    OneOf.OneOf<Identifier.OfID, Identifier.OfName, Identifier.OfNone> Value)
{
    public override string ToString()
        => Value.Match(
            static temp => $"<temp {temp.ID}>",
            static named => named.Name,
            static none => $"<unnamed>"
        );

    public static Identifier ID(ulong ID)
        => new(new OfID(ID));
    public static Identifier Name(string name)
        => new(new OfName(name));
    public static Identifier None
        => new(new OfNone());

    public bool IsID => Value.Index is 0;
    public bool IsName => Value.Index is 1;
    public bool IsNone => Value.Index is 2;

    public OfID AsID => Value.AsT0;
    public OfName AsName => Value.AsT1;

    public record struct OfName(string Name);
    public record struct OfID(ulong ID);
    public record struct OfNone;

    public static class Builtin
    {
        public static Identifier Self => Name("self");
    }
}
