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

    /// <summary>
    /// Apply the provided function as though through a Linq .Select,
    /// but do not reallocate if the function returns an equal value.
    /// </summary>
    public Seq<T> ThinMap<S>(Func<T, T, bool> equalityCheck, S state, Func<S, T, T> mapper)
    {
        var copy = null as ImmutableArray<T>.Builder;
        var result = this;

        for(int i = 0; i < Count; i++)
        {
            var mapped = mapper(state, this[i]);

            if(!equalityCheck(mapped, this[i]) && copy is null)
            {
                copy = ImmutableArray.CreateBuilder<T>(Count);
                copy.AddRange(result.values, i - 1);
            }

            copy?.Add(mapped);
        }

        if(copy is not null)
            return new(copy.ToImmutable());

        return this;
    }

    public bool ReferenceEquals(Seq<T> other)
    {
        return values == other.values;
    }

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