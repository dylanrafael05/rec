using Re.C.Types;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;

namespace Re.C.Syntax.Resolvers;

/// <summary>
/// A resolver type for types; this class
/// is responsible for resolving the syntax trees for
/// a typename into the type it represents.
/// 
/// Calls to this class' Visit method with non-typename
/// syntax trees are ill formed.
/// </summary>
public class TypeResolver(RecContext ctx) : RecBaseVisitor<RecType>
{
    public override RecType VisitTypenameSingle(RecParser.TypenameSingleContext single)
    {
        var def = ctx.Scopes.Current.DeepSearchOrDiagnose(
            [..from p in single.Ident._Parts select p.SourceSpan], 
            [..from p in single.Ident._Parts select p.TextAsIdentifier]);

        if(def is not NamedType namedType)
        {
            if(def is not null)
                ctx.Diagnostics.AddError(
                    single.CalculateSourceSpan(),
                    Errors.InvalidType(def));

            return ctx.BuiltinTypes.Error;
        }
        
        return namedType;
    }

    public override RecType VisitTypenamePointer([NotNull] RecParser.TypenamePointerContext context)
    {
        var inner = Visit(context.Base);

        if (inner.ContainsError)
            return inner;

        return RecType.Pointer(inner);
    }

    public override RecType VisitTypenameReference([NotNull] RecParser.TypenameReferenceContext context)
    {
        var inner = Visit(context.Base);

        if (inner.ContainsError)
            return inner;

        return RecType.Reference(inner);
    }

    public override RecType VisitTypenameArray([NotNull] RecParser.TypenameArrayContext context)
    {
        var inner = Visit(context.Base);

        if(inner.ContainsError)
            return inner;

        return RecType.Array(inner);
    }

    public override RecType VisitTypenameGeneric([NotNull] RecParser.TypenameGenericContext context)
    {
        var templateAny = ctx.Scopes.Current.DeepSearchOrDiagnose(
            [..from p in context.Base._Parts select p.SourceSpan], 
            [..from p in context.Base._Parts select p.TextAsIdentifier]);

        if(templateAny is null)
            return ctx.BuiltinTypes.Error;

        if(templateAny is not StructTemplate template)
        {
            ctx.Diagnostics.AddError(
                context.CalculateSourceSpan(),
                Errors.BadTypeInstantiationBase(templateAny));
            
            return ctx.BuiltinTypes.Error;
        }

        var args = context.Args._Args;

        if(template.TypeArguments.Length != args.Count)
        {
            ctx.Diagnostics.AddError(
                context.CalculateSourceSpan(),
                Errors.InvalidNumberOfTypeInstantiationArgs(template, args.Count));
            
            return ctx.BuiltinTypes.Error;
        }

        return RecType.TemplateInstance(
            template, [..from a in args select Visit(a)]);
    }
}
