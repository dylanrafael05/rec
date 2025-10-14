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
}
