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
    
    public Option<SourceSpan> DefinitionLocation { get; }
}

public abstract class DefinitionBase : IDefinition
{
    public Scope? Parent { get; set; }
    public required Identifier Identifier { get; init; }

    // TODO: remove 'option' here in favor of some kind of 'builtin' source
    public required Option<SourceSpan> DefinitionLocation { get; init; }
    public bool IsLinked { get; set; }

    public Source? DefinitionSource => DefinitionLocation
        .Map(x => x.Source).Or(null!);

    public override string ToString()
        => $"{GetType().Name} '{this.FullName}'";
}