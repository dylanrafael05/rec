using LLVMSharp.Interop;

namespace Re.C.Types.Descriptors;

public record struct TypeDescriptor(
    ulong Size,
    ulong Align,
    string Name,
    LLVMValueRef Destructor,
    FieldDescriptor[] Fields
);
