using LLVMSharp.Interop;
using Re.C.Syntax;
using Re.C.Visitor;

namespace Re.C.Compilation;

public partial class SyntaxCompiler
{
    private RecValue CompileInt(IntLiteral context)
        => LLVMValueRef.CreateConstIntOfArbitraryPrecision(
            context.Type.Compile(CTX),
            unchecked([(ulong)context.Value, (ulong)(context.Value >> (128 / 2))]));

    private RecValue CompileFloat(FloatLiteral context)
        => LLVMValueRef.CreateConstReal(
            context.Type.Compile(CTX),
            context.Value);
            
    private RecValue CompileString(StringLiteral context)
        => CTX.Builder.BuildGlobalString(context.Value);
}