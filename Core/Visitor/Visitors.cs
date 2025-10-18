using System.Runtime.CompilerServices;

namespace Re.C.Visitor;

/// <summary>
/// A helper static class containing extension methods defining the main
/// interfaces with which user code interacts with visitors.
/// </summary>
public static partial class Visitors
{
    public static void DefaultOnVisitUnbound<V, T>(V self, IVisitable value, VisitLabel label)
        where V : IStatefulVisitor<T>, allows ref struct
        where T : IVisitable
    {
        if (value is not T t)
            throw new InvalidCastException($"Visitor expected a value of type {typeof(T)}");

        self.OnVisit(t, label);
    }

    public static void DefaultBeforeVisitUnbound<V, T>(V self, IVisitable value, VisitLabel label)
        where V : IStatefulVisitor<T>, allows ref struct
        where T : IVisitable
    {
        if (value is not T t)
            throw new InvalidCastException($"Visitor expected a value of type {typeof(T)}");

        self.BeforeVisit(t, label);
    }
    
    public static void DefaultAfterVisitUnbound<V, T>(V self, IVisitable value, VisitLabel label)
        where V : IStatefulVisitor<T>, allows ref struct
        where T : IVisitable
    {
        if (value is not T t)
            throw new InvalidCastException($"Visitor expected a value of type {typeof(T)}");

        self.AfterVisit(t, label);
    }

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
        where T : IVisitable
    {
        DefaultVisit(visitor, value, new VisitLabel(label, Option.None));
    }

    public static void DefaultVisitUnbound<V>(V visitor, IVisitable value, string label)
        where V : IVisitor, allows ref struct
    {
        DefaultVisitUnbound(visitor, value, new VisitLabel(label, Option.None));
    }

    /// <summary>
    /// A variant of DefaultVisit which allows
    /// the caller to specify the child label.
    /// </summary>
    public static void DefaultVisit<V, T>(V visitor, T value, VisitLabel label)
        where V : IVisitor<T>, allows ref struct
        where T : IVisitable
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
    
    public static void DefaultVisitUnbound<V>(V visitor, IVisitable value, VisitLabel label)
        where V : IVisitor, allows ref struct
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
        where T : IVisitable
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

    public static void DefaultVisitManyUnbound<V>(V visitor, IEnumerable<IVisitable> collection, string label)
        where V : IVisitor, allows ref struct
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
        where T : IVisitable
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

    public static void DefaultVisitManyUnbound<V, I>(V visitor, IEnumerable<I> collection, Func<I, IVisitable> mapper, string label)
        where V : IVisitor, allows ref struct
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
    /// Visit the provided value using the provided stateful visitor reference.
    /// </summary>
    public static void VisitAsRef<V, T>(ref V visitor, T value, [CallerArgumentExpression(nameof(value))] string label = "")
        where V : IStatefulVisitor<T>
        where T : IVisitable
    {
        var rv = new RefVisitor<V, T>(ref visitor);
        rv.Visit(value, label);
    }


    /// <summary>
    /// A wrapper around a reference to a non-readonly visitor which
    /// implements the readonly visitor interface by exfiltrating the
    /// statefulness to the provided reference.
    /// </summary>
    private readonly ref struct RefVisitor<V, T>(ref V visitor) : IVisitor<T>
        where V : IStatefulVisitor<T>
        where T : IVisitable
    {
        private readonly ref V visitor = ref visitor;

        public bool ShouldContinue => visitor.ShouldContinue;

        void IStatefulVisitor<T>.AfterVisit(T value, VisitLabel label)
            => visitor.AfterVisit(value, label);
        void IStatefulVisitor.AfterVisit(IVisitable value, VisitLabel label)
            => DefaultAfterVisitUnbound<RefVisitor<V, T>, T>(this, value, label);

        void IStatefulVisitor<T>.BeforeVisit(T value, VisitLabel label)
            => visitor.BeforeVisit(value, label);
        void IStatefulVisitor.BeforeVisit(IVisitable value, VisitLabel label)
            => DefaultBeforeVisitUnbound<RefVisitor<V, T>, T>(this, value, label);

        void IStatefulVisitor<T>.OnVisit(T value, VisitLabel label)
            => visitor.OnVisit(value, label);
        void IStatefulVisitor.OnVisit(IVisitable value, VisitLabel label)
            => DefaultOnVisitUnbound<RefVisitor<V, T>, T>(this, value, label);

        public void Visit(T value, string label)
            => DefaultVisit(this, value, label);
        void IVisitor.Visit(IVisitable value, string label)
            => DefaultVisitUnbound(this, value, label);

        void IVisitor<T>.Visit(T value, VisitLabel label)
            => DefaultVisit(this, value, label);
        void IVisitor.Visit(IVisitable value, VisitLabel label)
            => DefaultVisitUnbound(this, value, label);

        void IVisitor<T>.VisitMany<C>(
            C values, string label)
            => DefaultVisitMany<RefVisitor<V, T>, C, T>(this, values, label);
        void IVisitor.VisitMany(
            IEnumerable<IVisitable> values, string label)
            => DefaultVisitManyUnbound(this, values, label);

        void IVisitor<T>.VisitMany<I>(
            IEnumerable<I> values, Func<I, T> mapper, string label)
            => DefaultVisitMany(this, values, mapper, label);
        void IVisitor.VisitMany<I>(
            IEnumerable<I> values, Func<I, IVisitable> mapper, string label)
            => DefaultVisitManyUnbound(this, values, mapper, label);
    }
}
