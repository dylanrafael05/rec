using System.Runtime.CompilerServices;

namespace Re.C.Types;

public class TypeSubstitutions
{
    public static TypeSubstitutions Of(params ReadOnlySpan<(TemplateType, RecType)> mappings)
    {
        var result = new TypeSubstitutions();

        foreach(var mapping in mappings)
            result.AddSubstitution(mapping.Item1, mapping.Item2);
            
        return result;
    }

    private readonly Dictionary<TemplateType, RecType> mappings = [];
    public IReadOnlyDictionary<TemplateType, RecType> Mappings => mappings;

    public bool ContainsSubstutionFor(TemplateType type)
        => mappings.ContainsKey(type);

    public RecType TrySubstitute(TemplateType type)
        => mappings.GetValueOrDefault(type) ?? type;

    public void AddSubstitution(TemplateType from, RecType to)
    {
        mappings.Add(from, to);
    }
}
