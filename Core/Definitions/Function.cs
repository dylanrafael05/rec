using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.Definitions;

public class Function : DefinitionBase
{
    public required Identifier[] ArgumentNames { get; init; }
    public required Variable?[] ArgumentDefs { get; init; }
    public required FunctionType Type { get; init; }
    public required Scope InnerScope { get; init; }
    public required bool IsExternal { get; init; }

    public Option<Block> Body { get; set; }
    public Option<LLVMValueRef> LLVMFunction { get; set; }

    public int ArgumentCount => ArgumentNames.Length;
}
