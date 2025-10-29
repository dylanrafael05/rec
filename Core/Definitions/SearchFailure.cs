namespace Re.C.Definitions;

/// <summary>
/// A type representing a failure to find a value within
/// some scope.
/// </summary>
[DiscriminatedUnion]
public partial record struct SearchFailure
{
    public static class Cases
    {
        public record struct NotFound;
        public record struct Ambiguous(List<IDefinition> Values);
    }
}

/// <summary>
/// A type representing a failure to find a value within
/// a chain of scopes.
/// </summary>
[DiscriminatedUnion]
public partial record struct DeepSearchFailure
{
    public static class Cases
    {
        public record struct Search(SearchFailure Inner, int OffendingIdentifier);
        public record struct NotAScope(IDefinition Def, int OffendingIdentifier);
    }
}
