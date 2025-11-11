namespace Re.C.Types.Descriptors;

public record struct TypeDescriptor(
    ulong Size,
    ulong Align,
    string Name,
    FieldDescriptor[] Fields
);
