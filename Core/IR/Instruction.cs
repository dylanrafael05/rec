using Re.C.Types;

namespace Re.C.IR;

public record Instruction(RecType Type, SourceSpan Span, InstructionKind Kind)
{
    public Option<ValueID> ValueID { get; set; }

    public override string ToString()
        => $"{ValueID.Unwrap()} = [{Type.FullName}] {Kind}";
}
