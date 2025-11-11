using Re.C.Definitions;

namespace Re.C.Types;

public abstract class NamedType : RecType, IDefinition
{
    public Scope? Parent { get; set; }
    public required Identifier Identifier { get; init; }
    public required SourceSpan DefinitionLocation { get; init; }
    public bool IsLinked { get; set; }

    public override bool Equals(RecType? other)
        => other is NamedType t
        && t.Identifier == Identifier
        && t.Parent == Parent;
    public override int GetHashCode()
        => HashCode.Combine(Identifier, Parent);

    public override string Name => Identifier.ToString();
    public override string FullName => (this as IDefinition).FullName;

    public override SourceSpan GetDefinitionLocation()
        => DefinitionLocation;
}
