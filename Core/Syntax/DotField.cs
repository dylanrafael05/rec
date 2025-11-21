namespace Re.C.Syntax;

[DiscriminatedUnion]
public readonly partial record struct DotField
{
    public static class Cases
    {
        public record struct Struct(int Index);
        public record struct ArraySize;
        public record struct ArrayPtr;
    }
}
