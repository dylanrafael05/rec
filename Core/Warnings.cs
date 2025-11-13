namespace Re.C;

/// <summary>
/// A helper class which provides a human-readable
/// interface for generating warning messages.
/// </summary>
public static class Warnings
{
    public static string UnnecessaryCast()
        => $"Cast is unnecessary.";

    public static string UnreachableCode()
        => $"Code is unreachable.";
}
