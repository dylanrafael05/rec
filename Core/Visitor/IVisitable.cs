namespace Re.C.Visitor;

/// <summary>
/// A type representing the label of a child with relation
/// to its visitable parent.
/// </summary>
public readonly record struct VisitLabel(string Label, Option<int> Index)
{
    public static implicit operator VisitLabel(string label)
        => new(label, Option.None);

    public override string ToString()
    {
        if (Index.IsNone)
        {
            return Label;
        }
        else
        {
            return $"{Label}[{Index.Unwrap()}]";
        }
    }
}

/// <summary>
/// An interface for types which can be visited.
/// </summary>
public interface IVisitable<out T>
    where T : IVisitable<T>
{
    public void PropogateVisitor<V>(V visitor)
        where V : IVisitor<T>, allows ref struct;
}