namespace Re.C.IR;

public record Instruction(Types.Type Type, SourceSpan Span, InstructionKind Kind)
{
    public Option<ValueID> ValueID { get; set; }

    public override string ToString()
        => $"{ValueID.Unwrap()} = [{Type.FullName}] {Kind}";
}
