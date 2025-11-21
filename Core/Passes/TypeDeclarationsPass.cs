using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;

namespace Re.C.Passes;

public class TypeDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitStructDefine([NotNull] RecParser.StructDefineContext context)
    {
        var span = context.CalculateSourceSpan();
        var type = new StructType
        {
            Identifier = context.Identifier().TextAsIdentifier,
            DefinitionLocation = span,
            TypeArguments = []
        };

        context.DefinedType = CTX.Scopes.Current.DefineOrDiagnose(
            span, type);

        context.DefinedType = type;

        return default;
    }
}
