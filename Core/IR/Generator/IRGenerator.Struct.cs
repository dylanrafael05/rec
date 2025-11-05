using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateStruct(StructExpression context)
    {
        var fields = (ValueID[])[..
            from f in context.Fields
            select Generate(f)
        ];

        return Builder.BuildInst(context, new InstructionKind.StructLiteral(fields));
    }
}