using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DiscriminatedUnion;

/// <summary>
/// A generator which creates a discriminated union-like interface
/// wrapping around OneOf
/// </summary>
[Generator]
public class Generator : IIncrementalGenerator
{
    public const string Attribute = "DiscriminatedUnionAttribute";
    public const string AttributeNamespace = "Re.C";

    public const string DUSource = @$"

// <auto generated> //

namespace {AttributeNamespace}
{{
    [System.AttributeUsage(System.AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class {Attribute} : System.Attribute
    {{}}
}}

";

    public static DiagnosticDescriptor NotMeetingSpec => new("DU001", 
        title: "DU must meet spec",
        messageFormat: "Discriminated union types must be top level partial record struct",
        category: "DiscriminatedUnion",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);
        
    public static DiagnosticDescriptor NoCases => new("DU002", 
        title: "DU must define 'Cases'",
        messageFormat: "Discriminated union must define 'public static class Cases'",
        category: "DiscriminatedUnion",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);
        
    public static DiagnosticDescriptor AtLeastOneCase => new("DU003", 
        title: "DU at least one case",
        messageFormat: "Discriminated union must have at least one case value",
        category: "DiscriminatedUnion",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(
            static ctx => ctx.AddSource($"{AttributeNamespace}.{Attribute}.g.cs", DUSource));

        var generator = context.SyntaxProvider.ForAttributeWithMetadataName(
                $"{AttributeNamespace}.{Attribute}",
                static (node, _) => node is TypeDeclarationSyntax @struct,
                static (ctx, _) => (ctx.TargetSymbol as INamedTypeSymbol, ctx.TargetNode as TypeDeclarationSyntax)
            );

        context.RegisterSourceOutput(generator, Execute);
    }

    public static string CSV<T>(IEnumerable<T> values)
        => string.Join(", ", values);

    public static string IfNotEmpty<T>(string value, T[] array)
        => array.Length == 0 ? "" : value;

    public void Execute(SourceProductionContext ctx, (INamedTypeSymbol, TypeDeclarationSyntax) input)
    {
        var (symbol, syntax) = input;

        var attributeLoc = symbol.Locations.FirstOrDefault() ?? Location.None;

        if(!symbol.IsRecord 
        || !symbol.IsValueType 
        || !syntax.Modifiers.Any(SyntaxKind.PartialKeyword) 
        || symbol.ContainingType is not null)
        {
            ctx.ReportDiagnostic(Diagnostic.Create(NotMeetingSpec, attributeLoc));
            return;
        }

        var cases = symbol.GetTypeMembers("Cases").FirstOrDefault();

        if(cases is null || !cases.IsStatic)
        {
            ctx.ReportDiagnostic(Diagnostic.Create(NoCases, attributeLoc));
            return;
        }

        var constituentTypes = Enumerable.ToArray(from node in cases.GetTypeMembers() 
            where node.IsRecord && node.IsValueType
            select node
        );
        
        if(constituentTypes.Length == 0)
        {
            ctx.ReportDiagnostic(Diagnostic.Create(AtLeastOneCase, attributeLoc));
            return;
        }

        var oneOfArgs = CSV( 
            from ty in constituentTypes select ty.ToDisplayString());

        var oneOf = $"OneOf.OneOf<{oneOfArgs}>";

        var output = new StringBuilder(@$"

namespace {symbol.ContainingNamespace.ToDisplayString()} 
{{
    partial record struct {symbol.Name}({oneOf} Value)
    {{

");

        var index = 0;

        foreach(var type in constituentTypes)
        {
            var args = Enumerable.ToArray(from mem in type.GetMembers()
                let prop = mem as IPropertySymbol
                where prop is not null 
                    && prop.DeclaredAccessibility is Accessibility.Public
                    && prop.Kind is SymbolKind.Property
                select prop
            );

            var typename = type.Name;

            output.Append(@$"

        /// Construct a {typename}
        public static {symbol.Name} {typename}
            {IfNotEmpty("(", args)}
            {CSV(from a in args select $"{a.Type.ToDisplayString()} {a.Name}")}
            {IfNotEmpty(")", args)}
            => new {symbol.Name}(new Cases.{typename}({
                CSV(from a in args select a.Name)}));

        private bool _Is{typename}({CSV(from a in args select $"out {a.Type.ToDisplayString()} {a.Name}")})
        {{
            if(Value.IsT{index})
            {{
                {CSV(from a in args select $"{a.Name} = Value.AsT{index}.{a.Name};")}
                return true;
            }}

            {CSV(from a in args select $"{a.Name} = default;")}
            return false;
        }}

        /// Check if this represents a {typename}
        public bool Is{typename} 
            {IfNotEmpty("(", args)} 
            {CSV(from a in args select $"out {a.Type.ToDisplayString()} {a.Name}")}
            {IfNotEmpty(")", args)}
            => _Is{typename}({CSV(from a in args select $"out {a.Name}")});

");

            index++;
        }

        output.Append(@$"

    }}
}}

");

        ctx.AddSource($"{symbol.ToDisplayString()}.g.cs", output.ToString());
    }
}