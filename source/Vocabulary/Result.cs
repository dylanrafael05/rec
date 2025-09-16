using OneOf;

namespace Re.C.Vocabulary;

/// <summary>
/// A helper type for wrapping the 'Ok' value
/// of a Result. Implicitly convertible to
/// <c>Result[<typeparamref name="T"/>, ?]</c>.
/// </summary>
public readonly record struct ResultOk<T>(T Value);

/// <summary>
/// A helper type for wrapping the 'Err' value
/// of a Result. Implicitly convertible to
/// <c>Result[<typeparamref name="T"/>, ?]</c>.
/// </summary>
public readonly record struct ResultErr<T>(T Value);

/// <summary>
/// A vocabulary type which represents either a
/// successful result, or an error.
/// </summary>
public readonly struct Result<T, E>
{
    public Result(T value)
    {
        _value = value;
    }

    public Result(E error)
    {
        _value = error;
    }

    private readonly OneOf<T, E> _value;

    public static implicit operator Result<T, E>(ResultOk<T> ok)
        => new(ok.Value);
    public static implicit operator Result<T, E>(ResultErr<T> err)
        => new(err.Value);

    public bool IsOk(out T value)
        => _value.TryPickT0(out value, out _);
    public bool IsErr(out E error)
        => _value.TryPickT1(out error, out _);

    public T Unwrap(string message = "Attempt to unwrap a 'None'")
    {
        if (IsOk(out var value))
            return value;

        throw new InvalidOperationException(message);
    }
}

/// <summary>
/// A helper class defining construction helpers
/// for the Result type.
/// </summary>
public static class Result
{
    public static ResultOk<T> Ok<T>(T value)
        => new(value);
    public static ResultErr<T> Err<T>(T value)
        => new(value);
}