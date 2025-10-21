using System.Linq.Expressions;
using System.Reflection;

namespace Re.C.Visitor.Expiremental;

// NOTE: this API is expiremental and was meant to reduce the boilerplate 
//       of iterating the subclasses of a type which was being extended by a visitor

public interface ITypeVisitor<in Type, Result>
    where Type : class
{
    public Result Visit(Type target) =>
        TypeVisitors.DefaultVisit<ITypeVisitor<Type, Result>, Type, Result>(this, target);
}

[AttributeUsage(AttributeTargets.Method)]
public class VisitCaseAttribute : Attribute
{}

public static class TypeVisitors
{
    private static class Storage<Visitor, T, Result>
        where T : class  
        where Visitor : ITypeVisitor<T, Result>
    {
        public delegate Result Delegate(Visitor visitor, T value);

        private static Dictionary<Type, Delegate> Implementations { get; } = [];

        private static Delegate CreateImplementation(Type target)
        {
            // Find all methods that look like a visit case handler
            var methods = typeof(Visitor).GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var method = methods.FirstOrDefault(m =>
                m.GetParameters() is var args 
                && args.Length == 1 
                && args[0].ParameterType.IsAssignableFrom(target)
                && m.ReturnType.IsAssignableTo(typeof(Result))
                && m.GetCustomAttribute<VisitCaseAttribute>() is not null);

            // Throw out invalid implementations
            if (method is null 
            || method.GetCustomAttribute<VisitCaseAttribute>() is null 
            || !method.ReturnType.IsAssignableTo(typeof(Result)))
                throw new InvalidOperationException($"Attempt to visit type {target} with visitor of type {typeof(Visitor)}, but {typeof(Visitor)} does not define a valid visit method for {target}");

            // Generate the allocation-free wrapper implementation
            var visitor = Expression.Parameter(typeof(Visitor));
            var value = Expression.Parameter(typeof(T));

            return Expression.Lambda<Delegate>(
                Expression.Call(
                    visitor, method,
                    Expression.Convert(value, target)
                ),
                visitor, value
            ).Compile();
        }

        public static Delegate GetImplementation(Type target)
        {
            if (Implementations.TryGetValue(target, out var impl))
                return impl;

            var result = CreateImplementation(target);
            Implementations[target] = result;
            return result;
        }
    }

    public static Result DefaultVisit<Visitor, T, Result>(Visitor visitor, T target)
        where T : class
        where Visitor : ITypeVisitor<T, Result>
    {
        var impl = Storage<Visitor, T, Result>.GetImplementation(
            target.UnwrapNull().GetType());
        
        return impl(visitor, target);
    }
}