using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueRef GenerateEnum(EnumExpression context)
        => Builder.Build(context.Type, context.Span, 
            new InstructionKind.IntLiteral((UInt128)context.Member.Value));
}