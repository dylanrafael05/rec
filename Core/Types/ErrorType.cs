using System.Runtime.CompilerServices;
using Antlr4.Runtime.Sharpen;
using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public class ErrorType : Type
{
    public override string Name => "<error>";
    public override string FullName => "<error>";

    public override bool Equals(Type? other)
        => other is ErrorType;
    public override int GetHashCode()
        => RuntimeHelpers.GetHashCode(this);

    public override LLVMValueRef BuildDestructor(RecContext ctx)
        => throw new NotSupportedException();
    public override FieldDescriptor[] GetFields(RecContext ctx)
        => throw new NotSupportedException();
    protected override LLVMTypeRef ImplementCompile(RecContext ctx)
        => throw new NotSupportedException();
}