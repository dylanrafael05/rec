namespace Re.C.Passes;

/// <summary>
/// A helper class holding all passes in the re:c
/// compiler.
/// </summary>
public readonly struct RecPasses
{
    public required FileDeclarationsPass FileDeclarations { get; init; }
    public required FileUsagesPass FileUsages { get; init; }
    public required TypeDeclarationsPass TypeDeclarations { get; init; }
    public required FunctionDeclarationsPass FunctionDeclarations { get; init; }
    public required TypeDefinitionsPass TypeDefinitions { get; init; }
    public required FunctionDefinitionsPass FunctionDefinitions { get; init; }

    public required IRGenerationPass IRGeneration { get; init; }

    public required LLVMDefinitionsPass LLVMDefinitions { get; init; }
    public required LLVMGenerationPass LLVMGeneration { get; init; }
}
