using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    private void GenerateLet(LetStatement context)
    {
        var value = Generate(context.TargetValue);
        LinkVariable(context.Variable, value);
    }
}