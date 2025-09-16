namespace Re.C.Definitions;

public interface IDefinition
{
    public Scope? Parent { get; set; }
    public Identifier Identifier { get; init; }
}

public abstract class DefinitionBase : IDefinition
{
    public Scope? Parent { get; set; }
    public required Identifier Identifier { get; init; }
}