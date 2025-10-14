namespace Re.C.Types.Descriptors;

public record struct FieldDescriptor(
    ulong Offset,
    TypeDescriptor FieldType,
    TypeDescriptor ParentType,
    string Name
);
