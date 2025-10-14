using LLVMSharp.Interop;
using Re.C.Types;

namespace Re.C.Definitions;

public class Function : DefinitionBase
{
    public required Identifier[] ArgumentNames { get; init; }
    public required FunctionType Type { get; init; }
    public Option<LLVMValueRef> LLVMFunction { get; set; }
}
