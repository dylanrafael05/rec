using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Types.Descriptors;
using Re.C.Vocabulary;

namespace Re.C.Types;

public class FunctionType : Type
{
    public required Type[] Parameters { get; init; }
    public required Type? Return { get; init; }

    private string GetName(Func<Type, string> stringifier)
    {
        var result = "fn("
            + string.Join(", ", from p in Parameters select stringifier(p))
            + ")";

        if (Return is not null)
            result += " " + stringifier(Return);

        return result;
    }

    public override string Name => GetName(t => t.Name);
    public override string FullName => GetName(t => t.FullName);


    public override LLVMValueRef BuildDestructor(CodegenContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(CodegenContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(CodegenContext ctx)
        => LLVMTypeRef.CreateFunction(
            Return?.GetLLVMType(ctx) ?? LLVMTypeRef.Void,
            [.. from p in Parameters select p.GetLLVMType(ctx)]
        );
}
