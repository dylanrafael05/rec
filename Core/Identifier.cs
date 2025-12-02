using System.Collections.Immutable;
using System.Runtime.CompilerServices;

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
        public static Identifier Size => Name("size");
        public static Identifier Ptr => Name("ptr");
        public static Identifier Drop => Name("drop");
    }
}

/// <summary>
/// A wrapper around a sequence of identifiers.
/// </summary>
public readonly record struct LongIdentifier(Seq<Identifier> Parts)
{
    public static LongIdentifier Create(params ReadOnlySpan<string> span)
    {
        var ary = new Identifier[span.Length];

        for(int i = 0; i < span.Length; i++)
            ary[i] = Identifier.Name(span[i]);

        return new([.. ary]);
    }
}
