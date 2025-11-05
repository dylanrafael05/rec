using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Re.C.Vocabulary;

/// <summary>
/// A helper class containing methods for all class types.
/// </summary>
public static class Objects
{
    public static T UnwrapNull<T>(
        this T? self,
        string message = "Expected a non-null value for {0}.",
        [CallerArgumentExpression(nameof(self))] string? arg = null)
        where T : class
        => self ?? throw Panic(string.Format(message, arg));

    public static U UnwrapAs<U>(
        this object? self,
        string message = "Expected {0} to be of type {1}.",
        [CallerArgumentExpression(nameof(self))] string? arg = null)
        where U : class
        => self as U ?? throw Panic(string.Format(message, arg, typeof(U).FullName));

    public static Option<U> As<U>(
        this object? self,
        string message = "Expected {0} to be of type {1}.",
        [CallerArgumentExpression(nameof(self))] string? arg = null)
        where U : class
        => Option.Nonnull(self as U);

    
    
    public static U? UnwrapAsOrNull<U>(
        this object? self,
        string message = "Expected {0} to be of type {1}.",
        [CallerArgumentExpression(nameof(self))] string? arg = null)
        where U : class
        => self is U r ? r : self is null ? null : throw Panic(string.Format(message, arg, typeof(U).FullName));

    /// <summary>
    /// A wrapper around GetType which does not allocate for struct types.
    /// </summary>
    public static Type GetType<T>(T? instance)
    {
        if (typeof(T).IsValueType)
            return typeof(T);

        return instance!.GetType();
    }
}
