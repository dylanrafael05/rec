namespace Re.C.Visitor;

public static partial class Visitors
{
    /// <summary>
    /// A struct visitor which appends to the provided list the first-level
    /// children of its provided visitable.
    /// </summary>
    public struct GetChildrenVisitor<T>(List<T> children) : IStatefulVisitor<T>
        where T : IVisitable
    {
        private bool isInFirstNode = false;
        public readonly bool ShouldContinue => !isInFirstNode;

        public readonly void AfterVisit(T value, VisitLabel label)
        { }

        public readonly void BeforeVisit(T value, VisitLabel label)
        {
            if (isInFirstNode)
            {
                children.Add(value);
            }
        }

        public void OnVisit(T value, VisitLabel label)
        {
            isInFirstNode = true;
        }
    }

    /// <summary>
    /// Add to the provided list the first-order children of this visitable.
    /// </summary>
    public static void GetChildren<T>(this T value, List<T> children)
        where T : IVisitable
    {
        var visitor = new GetChildrenVisitor<T>(children);
        VisitAsRef(ref visitor, value);
    }

    /// <summary>
    /// Allocate and populate a list of the first-order children of this visitable.
    /// </summary>
    public static List<T> GetChildren<T>(this T value)
        where T : IVisitable
    {
        var result = (List<T>)[];
        value.GetChildren(result);

        return result;
    }
}
