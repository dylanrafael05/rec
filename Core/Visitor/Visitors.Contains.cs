namespace Re.C.Visitor;

public static partial class Visitors
{
    /// <summary>
    /// A ref struct visitor which sets the result ref parameter to true
    /// if visiting a child which passes the provided predicate.
    /// </summary>
    public struct ContainsVisitor<T>(Predicate<T> predicate) : IStatefulVisitor<T>
        where T : IVisitable<T>
    {
        public bool result = false;

        public readonly bool ShouldContinue => !result;

        public readonly void AfterVisit(T value, VisitLabel label)
        { }

        public readonly void BeforeVisit(T value, VisitLabel label)
        { }

        public void OnVisit(T value, VisitLabel label)
        {
            if (predicate(value))
                result = true;
        }
    }

    /// <summary>
    /// Determine if the provided visitable ('this' parameter) contains a node
    /// which passes the provided predicate.
    /// </summary>
    public static bool Contains<T>(this T value, Predicate<T> predicate)
        where T : IVisitable<T>
    {
        var visitor = new ContainsVisitor<T>(predicate);
        VisitAsRef(ref visitor, value);

        return visitor.result;
    }
}
