using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Re.C.Vocabulary;

public static class SeqHelpers
{
    public static Seq<T> Create<T>(ReadOnlySpan<T> span)
        => new(ImmutableArray.Create(span));
}

/// <summary>
/// A read-only sequence which supports sequence equality
/// and sequence hashing.
/// </summary>
[CollectionBuilder(typeof(SeqHelpers), "Create")]
public readonly struct Seq<T>(ImmutableArray<T> values)
    : IReadOnlyList<T>
    , IEquatable<Seq<T>>
{
    private readonly ImmutableArray<T> values = values;

    public T this[int index] => values[index];
    public int Count => values.Length;

    public bool Equals(Seq<T> other)
    {
        if (values == other.values)
            return true;

        return values.SequenceEqual(other.values);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Seq<T> s && Equals(s);
    public override int GetHashCode()
        => values.SequenceHashCode();

    public ImmutableArray<T>.Enumerator GetEnumerator()
        => values.GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => ((IEnumerable<T>)values).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable)values).GetEnumerator();

    public static bool operator ==(Seq<T> left, Seq<T> right)
        => left.Equals(right);
    public static bool operator !=(Seq<T> left, Seq<T> right)
        => !(left == right);
}