using Re.C.IR;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.Definitions;

public class Function : DefinitionBase
{
    public override string DefinitionKind => "function";

    /// <summary>
    /// Note; since generic functions are more similar to normal functions
    /// than generic types they are treated as instances of the 'Function'
    /// class.
    /// </summary>
    public required TemplateType[] TemplateArguments { get; init;}

    public required Identifier[] ArgumentNames { get; init; }
    public required Variable?[] ArgumentDefs { get; init; }
    public required FunctionType Type { get; init; }
    public required Scope InnerScope { get; init; }
    public required Scope OuterScope { get; init;}
    public required bool IsExternal { get; init; }
    public required bool IsUnsafe { get; init; }
    public required bool HasReceiver { get; init; }

    public Option<Block> Body { get; set; }
    public Option<IRFunction> IRFunction { get; set; }

    public int ArgumentCount => ArgumentNames.Length;

    // todo; definition location
}
