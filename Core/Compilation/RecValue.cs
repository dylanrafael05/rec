using LLVMSharp.Interop;

namespace Re.C.Compilation;

public readonly record struct RecValue(Option<LLVMValueRef> Value)
{
    public static implicit operator RecValue(LLVMValueRef value)
        => new(Option.Some(value));
    public static RecValue None => new(Option.None);

    public readonly LLVMValueRef Unwrap() => Value.Unwrap();
}