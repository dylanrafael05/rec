using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Re.C.Vocabulary;

/// <summary>
/// A helper class for fatal error handling.
/// This class is globally-used so that Panic
/// is always visible.
/// </summary>
public static class ErrorHandling
{
    [Serializable]
    private class PanicException : Exception
    {
        public PanicException() { }
        public PanicException(string message) : base(message) { }
    }

    [Serializable]
    private class TodoException : Exception
    {
        public TodoException() : base("todo!") { }
        public TodoException(string reason) : base($"todo: {reason}") { }
    }
    
    [Serializable]
    private class UnimplementedException : Exception
    {
        public UnimplementedException() : base("unimplemented") { }
        public UnimplementedException(string reason) : base($"unimplemented: {reason}") { }
    }

    /// <summary>
    /// Throw the result of this function to signal
    /// a fatal error.
    /// </summary>
    public static Exception Panic(string error)
    {
        return new PanicException($"panic: {error}");
    }

    /// <summary>
    /// Throw the result of this function to signal
    /// that the code is not yet completed at this location.
    /// </summary>
    public static Exception Todo => new TodoException();

    /// <summary>
    /// Throw the result of this function to signal
    /// that the code is not unimplemented at this location.
    /// </summary>
    public static Exception Unimplemented => new UnimplementedException();
    
    /// <summary>
    /// Throw the result of this function to signal
    /// that the code is not unimplemented at this location.
    /// </summary>
    public static Exception UnimplementedBecause(string reason) => new UnimplementedException(reason);
    
    /// <summary>
    /// Throw the result of this function to signal
    /// that the code should be reachable at this location.
    /// </summary>
    public static Exception Unreachable => new System.Diagnostics.UnreachableException();
    
    /// <summary>
    /// Assert at runtime that a condition is true
    /// </summary>
    public static void Assert(bool condition, [CallerArgumentExpression(nameof(condition))] string msg = "")
    {
        if(!condition)
        {
            throw Panic($"assertion failed: {msg}");
        }
    }
}