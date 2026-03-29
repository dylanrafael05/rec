using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class TypeDefinitionsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitStructDefine([NotNull] RecParser.StructDefineContext context)
    {
        var template = context.DefinedType as StructTemplate;

        if(template is not null)
            CTX.Scopes.Enter(template.InternalScope);
        
        context.DefinedType.UnwrapNull().SetBody([..
            from field in context._Fields.Indexed
            select new Field(
                field.value.Name.TextAsIdentifier, 
                CTX.Resolvers.Type.Visit(field.value.FieldType),
                field.index)
        ]);

        if(template is not null)
            CTX.Scopes.Exit();

        return default;
    }

    public override Unit VisitEnumDefine([NotNull] RecParser.EnumDefineContext context)
    {
        var type = context.DefinedEnum.UnwrapNull();
        CTX.Scopes.Enter(type.InnerScope);
        var i = 0L;

        type.SetMembers([..
            from member in context._Members
            let span = member.CalculateSourceSpan()
            let def = new EnumMember
            {
                Value = member.Integer() is not null ? i = long.Parse(member.Integer().GetText()) : i++,
                Type = type,
                Identifier = member.Name.TextAsIdentifier,
                DefinitionLocation = span
            }
            let defined = CTX.Scopes.Current.DefineOrDiagnose(span, def)
            where defined is not null
            select defined
        ]);

        CTX.Scopes.Exit();
        return default;
    }
}