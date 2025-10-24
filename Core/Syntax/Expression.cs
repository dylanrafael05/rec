using Re.C.Visitor;

namespace Re.C.Syntax;

/// <summary>
/// The base class of all expression nodes in the bound syntax tree.
/// All subclasses of this must represent evaluable segments of code.
/// </summary>
public class Expression : BoundSyntax
{
    public required Types.Type Type { get; init; }
    
    [FieldOption(PrintLevel.Hidden)] 
    public virtual bool Assignable => false;
}
