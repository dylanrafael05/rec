namespace Re.C;

/// <summary>
/// 
/// </summary>
/// <param name="Value"></param>
public readonly record struct Identifier(
    OneOf.OneOf<Identifier.Temporary, Identifier.Named> Value)
{
    public override string ToString()
        => Value.Match(
            temp => $"<temp {temp.ID}>",
            named =>
            {
                var result = named.Name;

                if (named.AssociatedType is not null)
                    result = $"({named.AssociatedType.FullName}) {result}";

                return result;
            }
        );

    public static Identifier FromName(string name, Types.Type? associatedType = null)
        => new(new Named(name, associatedType));

    public static Identifier FromTempID(ulong ID)
        => new(new Temporary(ID));

    public static implicit operator Identifier(string name)
        => FromName(name);

    public bool IsTemp => Value.Index is 0;
    public bool IsNamed => Value.Index is 1;

    public record struct Named(string Name, Types.Type? AssociatedType = null);
    public record struct Temporary(ulong ID);
}