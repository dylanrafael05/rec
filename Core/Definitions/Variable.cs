using LLVMSharp.Interop;

namespace Re.C.Definitions;

public class Variable : DefinitionBase
{
    public required Types.Type Type { get; init; }
    public Option<LLVMValueRef> LLVMPointerValue { get; set; }
}
