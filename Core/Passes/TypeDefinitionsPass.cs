using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class TypeDefinitionsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitStructDefine([NotNull] RecParser.StructDefineContext context)
    {
        context.DefinedType.UnwrapNull().SetBody([..
            from field in context._Fields.Indexed
            select new StructType.Field(
                field.value.Name.TextAsIdentifier, 
                CTX.Resolvers.Type.Visit(field.value.FieldType),
                field.index)
        ]);

        return default;
    }
}