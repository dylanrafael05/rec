namespace Re.C.Types;

public class BuiltinTypes
{
    public required RecType Error { get; init; }
    public required RecType None { get; init; }
    
    public required RecType Bool { get; init; }

    public required RecType I8 { get; init; }
    public required RecType I16 { get; init; }
    public required RecType I32 { get; init; }
    public required RecType I64 { get; init; }
    public required RecType ISize { get; init; }

    public required RecType U8 { get; init; }
    public required RecType U16 { get; init; }
    public required RecType U32 { get; init; }
    public required RecType U64 { get; init; }
    public required RecType USize { get; init; }

    public required RecType F32 { get; init; }
    public required RecType F64 { get; init; }
}
