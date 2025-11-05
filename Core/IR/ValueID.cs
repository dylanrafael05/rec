namespace Re.C.IR;

public readonly record struct ValueID(IRFunction Function, long ID)
{
    public override string ToString()
        => $"_{ID}";
}
