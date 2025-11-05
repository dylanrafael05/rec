using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateLet(LetStatement context)
    {
        var value = Generate(context.TargetValue);
        LinkVariable(context.Variable, value);
    }
}