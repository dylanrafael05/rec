using System.Collections;
using OneOf;

namespace Re.C.Vocabulary;

/// <summary>
/// An empty helper type that is implicitly
/// convertible to an Option
/// </summary>
public record struct None();

/// <summary>
/// A helper class containing generic functions
/// for Option construction
/// </summary>
public static class Option
{
    public static Option<T> Some<T>(T value)
        => new(value);

    public static None None => new();
    public static Option<T> NoneOf<T>() => new();
}

/// <summary>
/// A vocabulary type that behaves as a OneOf<T, None>
/// </summary>
public readonly struct Option<T>
{
    public Option()
    {
        _value = new None();
    }

    public Option(T value)
    {
        _value = value;
    }

    public static implicit operator Option<T>(None _)
        => new();

    private readonly OneOf<None, T> _value;

    /// <summary>
    /// Test if this instance is 'None'
    /// </summary>
    public bool IsNone => _value.IsT0;
    /// <summary>
    /// Test if this instance contains a value,
    /// and unwrap the value into the provided
    /// variable if it does.
    /// </summary>
    public bool IsSome(out T value)
        => _value.TryPickT1(out value, out _);

    /// <summary>
    /// Produce a new option by calling a function
    /// on this instance's contained value, or 
    /// forwarding 'None' if there is no such value.
    /// </summary>
    public Option<V> Map<V>(Func<T, V> func)
    {
        if (IsSome(out var value))
            return Option.Some(func(value));

        return new None();
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

        throw new InvalidOperationException(message);
    }
}
