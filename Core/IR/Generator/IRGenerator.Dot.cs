using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateDot(DotExpression context)
    {
        var value = Generate(context.Inner);
        return Builder.BuildInst(context, 
            new InstructionKind.FieldCopy(value, context.FieldIndex));
    }

    public ValueID GenerateDotAsLHS(DotExpression context)
    {
        var ptr = GenerateAsLHS(context.Inner);
        return Builder.BuildInst(context, 
            new InstructionKind.FieldPtr(ptr, context.FieldIndex));
    }
}