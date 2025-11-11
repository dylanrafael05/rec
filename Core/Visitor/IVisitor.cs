using System.Runtime.CompilerServices;

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
public interface IVisitor<in T> : IStatefulVisitor<T>, IVisitor
    where T : IVisitable
{
    public void Visit(T value, [CallerArgumentExpression(nameof(value))] string label = "")
    {
        Visitors.DefaultVisit(this, value, label);
    }

    public void Visit(T value, VisitLabel label)
    {
        Visitors.DefaultVisit(this, value, label);
    }

    public void VisitMany<C>(
        C values,
        [CallerArgumentExpression(nameof(values))] string label = "")
        where C : IEnumerable<T>
    {
        Visitors.DefaultVisitMany<IVisitor<T>, C, T>(this, values, label);
    }

    public void VisitMany<I>(
        IEnumerable<I> values,
        Func<I, T> mapper,
        [CallerArgumentExpression(nameof(values))] string label = "")
    {
        Visitors.DefaultVisitMany(this, values, mapper, label);
    }
}

public interface IVisitor : IStatefulVisitor
{
    public void Visit(IVisitable value, [CallerArgumentExpression(nameof(value))] string label = "")
    {
        Visitors.DefaultVisitUnbound(this, value, label);
    }
    
    public void Visit(IVisitable value, VisitLabel label)
    {
        Visitors.DefaultVisitUnbound(this, value, label);
    }

    public void VisitMany(
        IEnumerable<IVisitable> values,
        [CallerArgumentExpression(nameof(values))] string label = "")
    {
        Visitors.DefaultVisitManyUnbound(this, values, label);
    }

    public void VisitMany<I>(
        IEnumerable<I> values,
        Func<I, IVisitable> mapper,
        [CallerArgumentExpression(nameof(values))] string label = "")
    {
        Visitors.DefaultVisitManyUnbound(this, values, mapper, label);
    }
}

/// <summary>
/// The interface of any visitor type. Note that classes
/// and readonly structs should *not* implement this
/// class directly, but should instead implement 
/// <see cref="IVisitor{T}"/>. This interface should only
/// ever be implemented by non-readonly structs.
/// </summary>
public interface IStatefulVisitor<in T> : IStatefulVisitor
    where T : IVisitable
{
    public void OnVisit(T value, VisitLabel label);

    public void BeforeVisit(T value, VisitLabel label);
    public void AfterVisit(T value, VisitLabel label);

    void IStatefulVisitor.OnVisit(IVisitable value, VisitLabel label)
        => Visitors.DefaultOnVisitUnbound<IStatefulVisitor<T>, T>(this, value, label);

    void IStatefulVisitor.BeforeVisit(IVisitable value, VisitLabel label)
        => Visitors.DefaultBeforeVisitUnbound<IStatefulVisitor<T>, T>(this, value, label);
    
    void IStatefulVisitor.AfterVisit(IVisitable value, VisitLabel label)
        => Visitors.DefaultAfterVisitUnbound<IStatefulVisitor<T>, T>(this, value, label);
}

public interface IStatefulVisitor
{
    public void OnVisit(IVisitable value, VisitLabel label);

    public void BeforeVisit(IVisitable value, VisitLabel label);
    public void AfterVisit(IVisitable value, VisitLabel label);

    public bool ShouldContinue { get; }
}