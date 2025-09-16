using Re.C.Definitions;
using Re.C.Vocabulary;

namespace Re.C.Types;

public abstract class NamedType : Type, IDefinition
{
    public Scope? Parent { get; set; }
    public required Identifier Identifier { get; init; }

    public override string Name => Identifier.ToString();
    public override string FullName => (this as IDefinition).FullName;
}
