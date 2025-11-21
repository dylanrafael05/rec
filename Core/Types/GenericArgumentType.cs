
namespace Re.C.Types;

public class GenericArgumentType : RecType
{
    public required int Index { get; init; }
    public required Identifier Identifier { get; init; }
    public required SourceSpan DefinitionLocation { get; init; }

    public override string Name => $"{Identifier}";
    public override string FullName => $"{Identifier}";

    public override bool Equals(RecType? other)
        => other is GenericArgumentType genarg 
        && genarg.Identifier == Identifier
        && genarg.DefinitionLocation == DefinitionLocation
        && genarg.Index == Index;

    public override int GetHashCode()
        => HashCode.Combine(Identifier, DefinitionLocation, Index);

    public override RecType ApplySubstitutions(TypeSubstitutions substitutions)
        => substitutions.TrySubstitute(this);
}
