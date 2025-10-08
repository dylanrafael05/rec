namespace Re.C.Visitor;

/// <summary>
/// An interface for types which are their own visitation
/// handlers.
/// </summary>
public interface IVisitable<T> : IVisitationHandler<T>
    where T : IVisitable<T>
{
    public void PropogateVisitor<V>(V visitor)
        where V : IVisitor<T>, allows ref struct;

    void IVisitationHandler<T>.PropogateVisitor<V>(T value, V visitor)
        => value.PropogateVisitor(visitor);
}

/// <summary>
/// An interface which provides a method for propogating down
/// a provided type.
/// </summary>
public interface IVisitationHandler<T>
{
    public void PropogateVisitor<V>(T value, V visitor)
        where V : IVisitor<T>, allows ref struct;
}