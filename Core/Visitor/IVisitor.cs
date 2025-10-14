namespace Re.C.Visitor;

/// <summary>
/// The interface of a 'readonly' visitor type; no
/// extra methods are added in this interface when
/// compared to <see cref="IStatefulVisitor{T}"/>, but there
/// is the added expectation that the visitor can function
/// as intended without boxing and without passing by
/// reference. 
/// 
/// This means that visitors which track an internal,
/// non-class state cannot implement this interface. These
/// visitors can still use the visitor syntax though,
/// as <see cref="Visitors"/> provides a method to use
/// these stateful visitors.
/// </summary>
public interface IVisitor<in T> : IStatefulVisitor<T>
{ }

/// <summary>
/// The interface of any visitor type. Note that classes
/// and readonly structs should *not* implement this
/// class directly, but should instead implement 
/// <see cref="IVisitor{T}"/>. This interface should only
/// ever be implemented by non-readonly structs.
/// </summary>
public interface IStatefulVisitor<in T>
{
    void OnVisit(T value);

    void BeforeVisit(T value);
    void AfterVisit(T value);

    bool ShouldContinue { get; }
}

/// <summary>
/// A helper static class containing extension methods defining the main
/// interfaces with which user code interacts with visitors.
/// </summary>
public static class Visitors
{
    /// <summary>
    /// The main interface with which visitors are interacted.
    /// 
    /// This must be defined as an extension method rather than a defaulted
    /// interface member to ensure ref struct support, as the defaulted member
    /// must box the 'this' parameter.
    /// </summary>
    public static void Visit<V, T>(this V visitor, T value)
        where V : IVisitor<T>, allows ref struct
        where T : IVisitable<T>
    {
        Visit(visitor, value, value);
    }

    /// <summary>
    /// A variant of <see cref="Visit{V, T}(V, T)"/> which accepts a 
    /// distinct visitation handler.
    /// </summary>
    public static void Visit<V, T, H>(this V visitor, T value, H visitationHandler)
        where V : IVisitor<T>, allows ref struct
        where H : IVisitationHandler<T>
    {
        visitor.BeforeVisit(value);

        if (visitor.ShouldContinue)
        {
            visitor.OnVisit(value);
            visitationHandler.PropogateVisitor(value, visitor);
        }

        visitor.AfterVisit(value);
    }

    /// <summary>
    /// A version of <see cref="Visit{V, T}(V, T)"/> which takes the
    /// visitor by reference and does not require it to be readonly.
    /// 
    /// This version does not, however, support ref struct inputs,
    /// as it is not allowed to take a reference to a ref struct.
    /// </summary>
    public static void Visit<V, T>(this ref V visitor, T value)
        where V : struct, IStatefulVisitor<T>
        where T : IVisitable<T>
    {
        var inner = new ExfiltrateStateVisitor<V, T>(ref visitor);
        inner.Visit(value);
    }

    /// <summary>
    /// A variant of <see cref="Visit{V, T}(ref V, T)"/> which accepts
    /// a distinct visitation handler.
    /// </summary>
    public static void Visit<V, T, H>(this ref V visitor, T value, H visitationHandler)
        where V : struct, IStatefulVisitor<T>
        where H : IVisitationHandler<T>
    {
        var inner = new ExfiltrateStateVisitor<V, T>(ref visitor);
        inner.Visit(value, visitationHandler);
    }

    /// <summary>
    /// A wrapper around a reference to a non-readonly visitor which
    /// implements the readonly visitor interface by exfiltrating the
    /// statefulness to the provided reference.
    /// </summary>
    public readonly ref struct ExfiltrateStateVisitor<V, T>(ref V visitor) : IVisitor<T>
        where V : IStatefulVisitor<T>
    {
        private readonly ref V visitor = ref visitor;

        public bool ShouldContinue => visitor.ShouldContinue;

        public void AfterVisit(T value)
        {
            visitor.AfterVisit(value);
        }

        public void BeforeVisit(T value)
        {
            visitor.BeforeVisit(value);
        }

        public void OnVisit(T value)
        {
            visitor.OnVisit(value);
        }
    }

    /// <summary>
    /// A ref struct visitor which sets the result ref parameter to true
    /// if visiting a child which passes the provided predicate.
    /// </summary>
    public struct ContainsVisitor<T>(Predicate<T> predicate)
        : IStatefulVisitor<T>
    {
        public bool result = false;

        public readonly bool ShouldContinue => !result;

        public readonly void AfterVisit(T value)
        { }

        public readonly void BeforeVisit(T value)
        { }

        public void OnVisit(T value)
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
        visitor.Visit(value);

        return visitor.result;
    }

    /// <summary>
    /// A struct visitor which appends to the provided list the first-level
    /// children of its provided visitable.
    /// </summary>
    public struct GetChildrenVisitor<T>(List<T> children) : IStatefulVisitor<T>
    {
        private bool isInFirstNode = false;
        public readonly bool ShouldContinue => !isInFirstNode;

        public readonly void AfterVisit(T value)
        { }

        public readonly void BeforeVisit(T value)
        {
            if (isInFirstNode)
            {
                children.Add(value);
            }
        }

        public void OnVisit(T value)
        {
            isInFirstNode = true;
        }
    }

    /// <summary>
    /// Add to the provided list the first-order children of this visitable.
    /// </summary>
    public static void GetChildren<T>(this T value, List<T> children)
        where T : IVisitable<T>
    {
        var visitor = new GetChildrenVisitor<T>(children);
        visitor.Visit(value);
    }

    /// <summary>
    /// Allocate and populate a list of the first-order children of this visitable.
    /// </summary>
    public static List<T> GetChildren<T>(this T value)
        where T : IVisitable<T>
    {
        var result = (List<T>)[];
        value.GetChildren(result);

        return result;
    }
}
