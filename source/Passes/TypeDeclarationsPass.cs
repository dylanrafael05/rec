using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class TypeDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitStructDefine([NotNull] RecParser.StructDefineContext context)
    {
        var type = new StructType
        {
            Identifier = context.Identifier().TextAsIdentifier
        };

        context.DefinedType = CTX.CurrentScope.DefineOrDiagnose(
            CTX,
            context.CalculateSourceSpan(),
            type);

        return default;
    }
}
