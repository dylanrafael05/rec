using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    public RecValue Compile(IntLiteral context)
        => LLVMValueRef.CreateConstIntOfArbitraryPrecision(
            context.Type.GetLLVMType(CTX),
            unchecked([(ulong)context.Value, (ulong)(context.Value >> (128 / 2))]));

    public RecValue Compile(FloatLiteral context)
        => LLVMValueRef.CreateConstReal(
            context.Type.GetLLVMType(CTX),
            context.Value);
            
    public RecValue Compile(StringLiteral context)
        => CTX.Builder.BuildGlobalString(context.Value);
}