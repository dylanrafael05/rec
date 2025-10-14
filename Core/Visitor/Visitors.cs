using System.Runtime.CompilerServices;

namespace Re.C.Visitor;

/// <summary>
/// A helper static class containing extension methods defining the main
/// interfaces with which user code interacts with visitors.
/// </summary>
public static partial class Visitors
{
    /// <summary>
    /// The main interface with which visitors are interacted.
    /// Automatically determines the child's label via CallerArgumentExpression. 
    /// If this is not desired, use the overload accepting the child label explicitly.
    /// 
    /// This must be defined as an extension method rather than a defaulted
    /// interface member to ensure ref struct support, as the defaulted member
    /// must box the 'this' parameter.
    /// </summary>
    public static void DefaultVisit<V, T>(V visitor, T value, string label)
        where V : IVisitor<T>, allows ref struct
        where T : IVisitable<T>
    {
        DefaultVisit(visitor, value, new VisitLabel(label, Option.None));
    }

    /// <summary>
    /// A variant of DefaultVisit which allows
    /// the caller to specify the child label.
    /// </summary>
    public static void DefaultVisit<V, T>(V visitor, T value, VisitLabel label)
        where V : IVisitor<T>, allows ref struct
        where T : IVisitable<T>
    {
        if (value is null)
        {
            return;
            throw Panic($"Cannot visit a null value (label was {label}).");
        }

        visitor.BeforeVisit(value, label);

        if (visitor.ShouldContinue)
        {
            visitor.OnVisit(value, label);
            value.PropogateVisitor(visitor);
        }

        visitor.AfterVisit(value, label);
    }

    public static void DefaultVisitMany<V, C, T>(V visitor, C collection, string label)
        where V : IVisitor<T>, allows ref struct
        where C : IEnumerable<T>
        where T : IVisitable<T>
    {
        var i = 0;

        foreach (var innerValue in collection)
        {
            visitor.Visit(
                innerValue,
                new VisitLabel(label, Option.Some(i))
            );
            i++;
        }
    }
    
    public static void DefaultVisitMany<V, C, I, T>(V visitor, C collection, Func<I, T> mapper, string label)
        where V : IVisitor<T>, allows ref struct
        where C : IEnumerable<I>
        where T : IVisitable<T>
    {
        var i = 0;

        foreach (var innerValue in collection)
        {
            visitor.Visit(
                mapper(innerValue),
                new VisitLabel(label, Option.Some(i))
            );
            i++;
        }
    }

    /// <summary>
    /// Wrap the provided stateful visitor reference into a ref visitor.
    /// Note that type deduction will not work with this method, and as such
    /// visit as ref is preferred.
    /// </summary>
    public static RefVisitor<V, T> Ref<V, T>(ref V visitor)
        where V : IStatefulVisitor<T>
        where T : IVisitable<T>
    {
        return new RefVisitor<V, T>(ref visitor);
    }

    /// <summary>
    /// Visit the provided value using the provided stateful visitor reference.
    /// </summary>
    public static void VisitAsRef<V, T>(ref V visitor, T value, [CallerArgumentExpression(nameof(value))] string label = "")
        where V : IStatefulVisitor<T>
        where T : IVisitable<T>
    {
        var rv = Ref<V, T>(ref visitor);
        rv.Visit(value, label);
    }


    /// <summary>
    /// A wrapper around a reference to a non-readonly visitor which
    /// implements the readonly visitor interface by exfiltrating the
    /// statefulness to the provided reference.
    /// </summary>
    public readonly ref struct RefVisitor<V, T>(ref V visitor) : IVisitor<T>
        where V : IStatefulVisitor<T>
        where T : IVisitable<T>
    {
        private readonly ref V visitor = ref visitor;

        public bool ShouldContinue => visitor.ShouldContinue;

        public void AfterVisit(T value, VisitLabel label)
        {
            visitor.AfterVisit(value, label);
        }

        public void BeforeVisit(T value, VisitLabel label)
        {
            visitor.BeforeVisit(value, label);
        }

        public void OnVisit(T value, VisitLabel label)
        {
            visitor.OnVisit(value, label);
        }

        public void Visit(T value, string label)
            => DefaultVisit(this, value, label);
        public void Visit(T value, VisitLabel label)
            => DefaultVisit(this, value, label);
        public void VisitMany<C>(
            C values,
            [CallerArgumentExpression(nameof(values))] string label = "")
            where C : IEnumerable<T>
            => DefaultVisitMany<RefVisitor<V, T>, C, T>(this, values, label);
        
        public void VisitMany<I>(
            IEnumerable<I> values,
            Func<I, T> mapper,
            [CallerArgumentExpression(nameof(values))] string label = "")
            => DefaultVisitMany(this, values, mapper, label);
    }
}
