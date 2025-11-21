namespace Re.C.Types;

// TODO; use the newly created 'field' API to reimplement array type's 'size' and 'ptr' members
// TODO; add the notion of 'unassignable' fields to account for the above
public record struct Field(Identifier Name, RecType Type, int Index);
