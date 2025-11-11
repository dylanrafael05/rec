using Re.C.Types;

namespace Re.C.Definitions;

public class Variable : DefinitionBase
{
    public required RecType Type { get; init; }
}
