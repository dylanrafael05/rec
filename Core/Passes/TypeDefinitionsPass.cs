using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;

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
}