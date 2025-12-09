using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public ValueRef GenerateError(ErrorExpression context)
    {
        return Builder.BuildError(context);
    }
    
    public void GenerateError(ErrorStatement context)
    {}
}