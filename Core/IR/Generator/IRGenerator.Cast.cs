using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateCast(CastExpression context)
    {
        var inner = Generate(context.Value);
        return Builder.BuildInst(context, new InstructionKind.BuiltinCast(inner));
    }
}