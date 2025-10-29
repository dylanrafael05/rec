using System.Collections;
using OneOf;

namespace Re.C.Vocabulary;

/// <summary>
/// A helper class containing generic functions
/// for Option construction
/// </summary>
public static class Option
{
    /// <summary>
    /// An empty helper type that is implicitly
    /// convertible to an Option
    /// </summary>
    public record struct NoneHelper();

    public static Option<T> Some<T>(T value)
        => Option<T>.Some(value);

    public static NoneHelper None => new();
    public static Option<T> NoneOf<T>() => Option<T>.None;

    public static Option<T> Nonnull<T>(T? value)
        where T : class
        => value is null ? None : Some(value);

    public static Option<T> If<T>(bool condition, T get)
        => condition ? Some(get) : NoneOf<T>();
    public static Option<T> If<T>(bool condition, Func<T> get)
        => condition ? Some(get()) : NoneOf<T>();
}

/// <summary>
/// A vocabulary type that behaves as a OneOf<T, None>
/// </summary>
[DiscriminatedUnion]
public readonly partial record struct Option<T> : IEnumerable<T>
{
    public static class Cases
    {
        public readonly record struct None;
        public readonly record struct Some(T Value);
    }

    public static implicit operator Option<T>(Option.NoneHelper _)
        => new();

    /// <summary>
    /// Produce a new option by calling a function
    /// on this instance's contained value, or 
    /// forwarding 'None' if there is no such value.
    /// </summary>
    public Option<V> Map<V>(Func<T, V> func)
    {
        if (IsSome(out var value))
            return Option.Some(func(value));

        return new();
    }

    /// <summary>
    /// Get the underlying value, throwing an
    /// <see cref="InvalidOperationException"/> if
    /// there is none.
    /// </summary>
    public T Unwrap(string message = "Attempt to unwrap a 'None'")
    {
        if (IsSome(out var value))
            return value;

        throw Panic(message);
    }

    /// <summary>
    /// Get the underlying value, or the value provided.
    /// </summary>
    public T Or(T @else)
    {
        if (IsSome(out var value))
            return value;

        return @else;
    }

    /// <summary>
    /// A zero-allocation implementation of an enumerator over an enumerable.
    /// </summary>
    public struct Enumerator(Option<T> value) : IEnumerator<T>
    {
        private bool atEnd = value.IsNone;

        public readonly T Current => atEnd 
            ? throw new InvalidOperationException() 
            : value.Unwrap();
        readonly object? IEnumerator.Current => Current;

        public readonly void Dispose()
        {}

        public bool MoveNext()
        {
            atEnd = true;
            return false;
        }

        public void Reset()
            => atEnd = value.IsNone;
    }

    /// <summary>
    /// Get an enumerator of this.
    /// </summary>
    public Enumerator GetEnumerator()
        => new(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
