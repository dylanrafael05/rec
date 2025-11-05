using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Types;
using Re.C.Visitor;

namespace Re.C.IR;

public partial class IRGenerator
{
    private ValueID GenerateFunctionRef(FunctionExpression context)
        => Builder.BuildInst(new PointerType { Pointee = context.Type }, context.Span, 
            new InstructionKind.FunctionLiteral(context.Function));
}