namespace Re.C.Types;

public class BuiltinTypes
{
    public required Type Bool { get; init; }

    public required Type I8 { get; init; }
    public required Type I16 { get; init; }
    public required Type I32 { get; init; }
    public required Type I64 { get; init; }
    public required Type ISize { get; init; }

    public required Type U8 { get; init; }
    public required Type U16 { get; init; }
    public required Type U32 { get; init; }
    public required Type U64 { get; init; }
    public required Type USize { get; init; }

    public required Type F32 { get; init; }
    public required Type F64 { get; init; }
}
