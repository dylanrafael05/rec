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
            temp => $"<temp {temp.ID}>",
            named =>
            {
                var result = named.Name;

                if (named.AssociatedType is not null)
                    result = $"({named.AssociatedType.FullName}) {result}";

                return result;
            },
            none => $"<unnamed>"
        );

    public static Identifier ID(ulong ID)
        => new(new OfID(ID));
    public static Identifier Name(string name, Types.Type? associatedType = null)
        => new(new OfName(name, associatedType));
    public static Identifier None
        => new(new OfNone());

    public bool IsID => Value.Index is 0;
    public bool IsName => Value.Index is 1;
    public bool IsNone => Value.Index is 2;

    public OfID AsID => Value.AsT0;
    public OfName AsName => Value.AsT1;

    public record struct OfName(string Name, Types.Type? AssociatedType = null);
    public record struct OfID(ulong ID);
    public record struct OfNone;
}
