using Re.C.Definitions;
using Re.C.Vocabulary;

namespace Re.C.Types;

public abstract class NamedType : Type, IDefinition
{
    public Scope? Parent { get; set; }
    public required Identifier Identifier { get; init; }
    public required Option<SourceSpan> DefinitionLocation { get; init; }
    public bool IsLinked { get; set; }

    public override bool Equals(Type? other)
        => other is NamedType t
        && t.Identifier == Identifier
        && t.Parent == Parent;
    public override int GetHashCode()
        => HashCode.Combine(Identifier, Parent);

    public override string Name => Identifier.ToString();
    public override string FullName => (this as IDefinition).FullName;

    public override Option<SourceSpan> GetDefinitionLocation()
        => DefinitionLocation;
}
