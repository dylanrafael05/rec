namespace Re.C;

/// <summary>
/// A wrapper type representing a unique identifier.
/// Can either be a source-referencable name with optional associated type,
/// or a compiler-internal numeric ID.
/// </summary>
[DiscriminatedUnion]
public readonly partial record struct Identifier
{
    public static class Cases
    {
        public record struct ID(int Value);
        public record struct Name(string Value);
        public record struct None;
    }

    public override string ToString()
        => Value.Match(
            static temp => $"<temp {temp.Value}>",
            static named => named.Value,
            static none => $"<unnamed>"
        );

    public static class Builtin
    {
        public static Identifier Self => Name("self");
    }
}
