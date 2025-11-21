using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Syntax;

/// <summary>
/// The base class of all expression nodes in the bound syntax tree.
/// All subclasses of this must represent evaluable segments of code.
/// </summary>
public class Expression : BoundSyntax
{
    public required RecType Type { get; init; }
    
    [FieldOption(PrintLevel.Hidden)] 
    public virtual bool HasAddress => false;
    [FieldOption(PrintLevel.Hidden)]
    public virtual bool CanBeAssigned => false;

    public override bool IsError => Type is ErrorType;
}
