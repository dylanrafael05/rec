using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Re.C.Vocabulary;

/// <summary>
/// A helper class containing methods for all class types.
/// </summary>
public static class Objects
{
    extension<T>(T? self) where T : class
    {
        public T UnwrapNull(string message = "Expected a non-null value for {}.", [CallerArgumentExpression(nameof(self))] string? arg = null)
            => self ?? throw Panic(string.Format(message, arg));
    }

    extension(object? self)
    {
        public U UnwrapAs<U>(string message = "Expected {} to be of type {}.", [CallerArgumentExpression(nameof(self))] string? arg = null)
            where U : class
            => self as U ?? throw Panic(string.Format(message, arg, typeof(U).FullName));
    }
}
