using Re.C.Types;

namespace Re.C.Definitions;

public class Variable : DefinitionBase
{
    public override string DefinitionKind => "variable";
    public required RecType Type { get; init; }
}
