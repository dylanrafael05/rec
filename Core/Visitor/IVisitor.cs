using System.Runtime.CompilerServices;
using OneOf.Types;

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
    where T : IVisitable<T>
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

/// <summary>
/// The interface of any visitor type. Note that classes
/// and readonly structs should *not* implement this
/// class directly, but should instead implement 
/// <see cref="IVisitor{T}"/>. This interface should only
/// ever be implemented by non-readonly structs.
/// </summary>
public interface IStatefulVisitor<in T>
    where T : IVisitable<T>
{
    public void OnVisit(T value, VisitLabel label);

    public void BeforeVisit(T value, VisitLabel label);
    public void AfterVisit(T value, VisitLabel label);

    public bool ShouldContinue { get; }
}