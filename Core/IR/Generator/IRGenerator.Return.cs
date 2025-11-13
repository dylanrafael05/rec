using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public void GenerateReturn(ReturnStatement context)
    {
        var val = context.Value.Map(Generate);

        if(!val.IsSome(out var id))
        {
            id = Builder.Build(context, new InstructionKind.NoneLiteral());
        }
        
        Builder.Build(context, new InstructionKind.Return(id));
    }
}