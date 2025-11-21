using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateIndex(IndexExpression context)
    {
        var addr = GenerateIndexAsLHS(context);
        return Builder.Build(
            context, new InstructionKind.Load(addr));
    }

    private ValueID GenerateIndexAsLHS(IndexExpression context)
    {
        return Builder.Build(
            RecType.Pointer(context.Type), 
            context.Span,
            new InstructionKind.IndexAddress(
                Generate(context.Target),
                Generate(context.Index)
            ));
    }
}