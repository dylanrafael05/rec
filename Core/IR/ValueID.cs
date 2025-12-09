namespace Re.C.IR;

public readonly record struct ValueID(IRFunction Function, long ID)
{
    public override string ToString()
        => $"%{ID}";

    public Instruction Instruction => Function.InstructionByValue(this);
}

public readonly struct ValueRef(ValueID value, Option<SourceSpan> referenceSpan)
{
    public override string ToString()
        => $"{Value}";

    public ValueID Value { get; } = value;
    public SourceSpan ReferenceSpan { get; } = referenceSpan.Or(value.Instruction.Span);

    public static implicit operator ValueID(ValueRef self)
        => self.Value;
    public static implicit operator ValueRef(ValueID self)
        => new(self, Option.None);

    public static ValueRef WithSpan(ValueID value, SourceSpan span)
        => new(value, Option.Some(span));
}