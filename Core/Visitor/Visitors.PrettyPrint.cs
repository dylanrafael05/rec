using System.Reflection;
using System.Text;

namespace Re.C.Visitor;

public enum PrintLevel
{
    Hidden,
    Verbose
}

public class FieldOptionAttribute : Attribute
{
    public PrintLevel Level { get; init; }

    public FieldOptionAttribute(PrintLevel level)
    {
        Level = level;
    }
}

public static partial class Visitors
{
    public struct PrettyPrintVisitor<T>(StringBuilder output, bool verbose) : IStatefulVisitor<T>
        where T : IVisitable
    {
        public static readonly Type IEnumerableOfT
            = typeof(IEnumerable<>).MakeGenericType(typeof(T));

        public int depth = 0;

        public readonly bool ShouldContinue => true;

        private readonly void Tab()
        {
            for (int i = 0; i < depth; i++)
                output.Append("|\t");
        }

        public void AfterVisit(T value, VisitLabel label)
        {
            depth--;
        }

        public void BeforeVisit(T value, VisitLabel label)
        {
            depth++;
        }

        public void OnVisit(T value, VisitLabel label)
        {
            if (value is null)
                return;

            depth--;
            Tab();
            depth++;
            output.Append($"{label} ({value.GetType().Name})").AppendLine();

            foreach(var prop in value.GetType().GetProperties())
            {
                if (prop.PropertyType.IsAssignableTo(typeof(T)))
                    continue;

                if (prop.PropertyType.IsAssignableTo(IEnumerableOfT))
                    continue;

                var option = prop.GetCustomAttribute<FieldOptionAttribute>();
                if (option is not null)
                {
                    if (option.Level is PrintLevel.Hidden)
                        continue;

                    if (!verbose && option.Level is PrintLevel.Verbose)
                        continue;
                }

                Tab();
                output.Append($".{prop.Name} = {prop.GetValue(value)}").AppendLine();
            }

            foreach(var prop in value.GetType().GetFields())
            {
                if (prop.FieldType.IsAssignableTo(typeof(T)))
                    continue;

                if (prop.FieldType.IsAssignableTo(IEnumerableOfT))
                    continue;
                    
                var option = prop.GetCustomAttribute<FieldOptionAttribute>();
                if (option is not null)
                {
                    if (option.Level is PrintLevel.Hidden)
                        continue;

                    if (!verbose && option.Level is PrintLevel.Verbose)
                        continue;
                }

                Tab();
                output.Append($".{prop.Name} = {prop.GetValue(value)}").AppendLine();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static string PrettyPrint<T>(this T value, bool verbose = false)
        where T : IVisitable
    {
        var output = new StringBuilder();
        var visitor = new PrettyPrintVisitor<T>(output, verbose);
        VisitAsRef(ref visitor, value, "<Value>");

        return output.ToString();
    }
}
