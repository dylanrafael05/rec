using System.Diagnostics.CodeAnalysis;

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
[DiscriminatedUnion]
public readonly partial record struct Result<T, E>
{
    public static class Cases
    {
        public readonly record struct Ok(T Value);
        public readonly record struct Err(E Error);
    }

    public static implicit operator Result<T, E>(ResultOk<T> ok)
        => Ok(ok.Value);
    public static implicit operator Result<T, E>(ResultErr<E> err)
        => Err(err.Value);

    public Result<X, E> MapOk<X>(Func<T, X> mapper)
    {
        if(IsOk(out var value))
            return Result<X, E>.Ok(mapper(value));

        IsErr(out var err);
        return Result<X, E>.Err(err);
    }

    public Result<T, X> MapErr<X>(Func<E, X> mapper)
    {
        if(IsErr(out var err))
            return Result<T, X>.Err(mapper(err));

        IsOk(out var value);
        return Result<T, X>.Ok(value);
    }

    public T Unwrap(string message = "Attempt to unwrap a 'None'")
    {
        if (IsOk(out var value))
            return value;

        throw new InvalidOperationException(message);
    }

    [return: NotNullIfNotNull(nameof(@else))]
    public T? Or(T? @else)
    {
        if (IsOk(out var value))
            return value;

        return @else;
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