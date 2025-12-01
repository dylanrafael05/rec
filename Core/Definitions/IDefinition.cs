namespace Re.C.Definitions;

public interface IDefinition
{
    public Scope? Parent { get; set; }
    public Identifier Identifier { get; init; }

    /// <summary>
    /// A linked definition is one whose parent is aware
    /// of their existence. Non-linked, or "orphaned" 
    /// definitions are most useful for creating scopes 
    /// for functions.
    /// </summary>
    public bool IsLinked { get; set; }
    
    public SourceSpan DefinitionLocation { get; }
    public string DefinitionKind { get; }
}

public abstract class DefinitionBase : IDefinition
{
    public Scope? Parent { get; set; }
    public required Identifier Identifier { get; init; }

    public required SourceSpan DefinitionLocation { get; init; }
    public bool IsLinked { get; set; }

    public Source DefinitionSource => DefinitionLocation.Source;
    public abstract string DefinitionKind { get; }

    public override string ToString()
        => $"{GetType().Name} '{this.FullName}'";
}