using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public void GenerateReturn(ReturnStatement context)
    {
        var val = context.Value.Map(Generate);

        if(!val.IsSome(out var id))
        {
            id = Builder.BuildInst(context, new InstructionKind.NoneLiteral());
        }
        
        Builder.BuildInst(context, new InstructionKind.Return(id));
    }
}