using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateFunctionRef(FunctionExpression context)
        => Builder.BuildInst(RecType.Pointer(context.Type), context.Span, 
            new InstructionKind.FunctionLiteral(context.Function));
}