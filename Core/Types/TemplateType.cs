
namespace Re.C.Types;

public class TemplateType : NamedType
{
    public required int Index { get; init; }

    public override string Name => $"{Identifier}";
    public override string FullName => $"{Identifier}";

    public override bool Equals(RecType? other)
        => other is TemplateType genarg 
        && genarg.Identifier == Identifier
        && genarg.DefinitionLocation == DefinitionLocation
        && genarg.Index == Index;

    public override int GetHashCode()
        => HashCode.Combine(Identifier, DefinitionLocation, Index);

    public override RecType ApplySubstitutions(TypeSubstitutions substitutions)
        => substitutions.TrySubstitute(this);
}
