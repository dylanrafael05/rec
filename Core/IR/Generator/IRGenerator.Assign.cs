using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateAssign(AssignStatement context)
    {
        var target = GenerateAsLHS(context.Target);
        var value = Generate(context.Value);

        Builder.BuildInst(context, new InstructionKind.Store(target, value));
    }
}