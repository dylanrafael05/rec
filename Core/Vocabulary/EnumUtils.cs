using System.Linq.Expressions;
using System.Reflection;

namespace Re.C.Vocabulary;

/// <summary>
/// An exception thrown when enum repr operations fail.
/// </summary>
[Serializable]
public class EnumReprException : Exception
{
    public EnumReprException() {}
}

/// <summary>
/// An attribute for storing the "repr" associated with an
/// enum value. If this attribute is missing, repr methods
/// will instead use the name of the enum value.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class EnumReprAttribute(string repr) : Attribute
{
    public string Repr { get; } = repr;
}

/// <summary>
/// A helper class which mostly implements the association
/// between enum values and their 'repr'.
/// </summary>
public static class EnumUtils
{
    private static class ReprConverters<T>
        where T : struct, Enum
    {
        public static (Func<T, string> To, Func<string, T> From) Impl = GetImpl();

        public static (Func<T, string>, Func<string, T>) GetImpl()
        {
            // Use the expression API to generate then compile
            // functions for conversion to and from the repr
            // without any allocations.
            var inputT = Expression.Parameter(typeof(T));
            var inputStr = Expression.Parameter(typeof(string));

            var outputT = Expression.Label(typeof(T));
            var outputStr = Expression.Label(typeof(string));

            var casesToT = new List<SwitchCase>();
            var casesFromT = new List<SwitchCase>();

            foreach (var name in Enum.GetNames<T>())
            {
                var value = Enum.Parse<T>(name);

                var repr = typeof(T).GetField(name).UnwrapNull()
                    .GetCustomAttribute<EnumReprAttribute>()
                    ?.Repr ?? name;

                // Generate the switch case for both directions 
                casesToT.Add(Expression.SwitchCase(
                    Expression.Return(outputT,
                        Expression.Constant(value)
                    ),
                    Expression.Constant(repr)
                ));

                casesFromT.Add(Expression.SwitchCase(
                    Expression.Return(outputStr,
                        Expression.Constant(repr)
                    ),
                    Expression.Constant(value)
                ));
            }

            var throwIOE = Expression.Throw(Expression.New(typeof(EnumReprException)));

            // Compile the lambdas into functions and return them
            var toT = Expression.Lambda<Func<T, string>>(
                Expression.Block(
                    Expression.Switch(inputT, throwIOE, [.. casesFromT]),
                    Expression.Label(outputStr, Expression.Constant(""))
                ),
                inputT
            ).Compile();

            var fromT = Expression.Lambda<Func<string, T>>(
                Expression.Block(
                    Expression.Switch(inputStr, throwIOE, [.. casesToT]),
                    Expression.Label(outputT, Expression.Constant(default(T)))
                ),
                inputStr
            ).Compile();

            return (toT, fromT);
        }
    }

    extension<T>(T)
        where T : struct, Enum
    {
        public static string GetRepr(T value)
            => ReprConverters<T>.Impl.To(value);
        public static T FromRepr(string value)
            => ReprConverters<T>.Impl.From(value);
    }
}