using Re.C.Types;

namespace Re.C.Definitions;

public class EnumMember : DefinitionBase
{
    public override string DefinitionKind => "enum member";
    public required EnumType Type { get; init; }
    public required long Value { get; init; }
}