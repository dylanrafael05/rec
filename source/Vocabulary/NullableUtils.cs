using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Re.C.Vocabulary;

public static class NullableUtils
{
    public static T UnwrapNull<T>(this T? self, string message = "Expected a non-null value for {}.", [CallerArgumentExpression(nameof(self))] string? arg = null)
        where T : class
        => self ?? throw Panic(string.Format(message, arg));
}
