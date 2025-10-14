namespace Re.C.Passes;

/// <summary>
/// A helper class holding all passes in the re:c
/// compiler.
/// </summary>
public readonly struct RecPasses
{
    public required FileDeclarationsPass FileDeclarations { get; init; }
    public required TypeDeclarationsPass TypeDeclarations { get; init; }
    public required FunctionDeclarationsPass FunctionDeclarations { get; init; }
    public required TypeDefinitionsPass TypeDefinitions { get; init; }
    public required FunctionDefinitionsPass FunctionDefinitions { get; init; }
}
