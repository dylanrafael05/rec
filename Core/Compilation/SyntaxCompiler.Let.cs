using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private void CompileLet(LetStatement context)
    {
        var value = Compile(context.TargetValue);
        LinkVariable(context.Variable, value);
    }

    private void LinkVariable(Variable var, RecValue value)
    {
        if(var.Type is not NoneType)
        {
            var ptr = CTX.Builder.BuildAlloca(var.Type.Compile(CTX));
            CTX.Builder.BuildStore(value.Unwrap(), ptr);
            
            var.LLVMPointerValue = Option.Some(ptr);
        }
    }
}