namespace Re.C.Types;

public class TypeSubstitutions
{
    private readonly Dictionary<GenericArgumentType, RecType> mappings = [];
    public IReadOnlyDictionary<GenericArgumentType, RecType> Mappings => mappings;

    public bool ContainsSubstutionFor(GenericArgumentType type)
        => mappings.ContainsKey(type);

    public RecType TrySubstitute(GenericArgumentType type)
        => mappings.GetValueOrDefault(type) ?? type;

    public void AddSubstitution(GenericArgumentType from, RecType to)
    {
        mappings.Add(from, to);
    }
}
