using Re.C.Definitions;

namespace Re.C;

/// <summary>
/// A helper class which provides a human-readable
/// interface for generating error messages.
/// </summary>
public static class Errors
{
    public static string UndefinedInCurrentScope(Identifier name)
        => $"Could not find a definition of '{name}' in current context";
    public static string UndefinedInGivenScope(Identifier name, IDefinition scope)
        => $"Could not find a definition of '{name}' in '{scope}'";
    public static string InvalidScopeResolutionTarget()
        => $"Cannot use '.' here; target is not a scope";
    public static string Redefinition(Identifier name, Scope scope)
        => $"Redefinition of '{name}' in '{scope}'";
}