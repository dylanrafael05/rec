using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueID GenerateError(ErrorExpression context)
    {
        return Builder.BuildError(context);
    }
    
    public void GenerateError(ErrorStatement context)
    {}
}