using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Types.Descriptors;
using Re.C.Vocabulary;

namespace Re.C.Types;

public class FunctionType : Type
{
    public required Seq<Type> Parameters { get; init; }
    public required Type? Return { get; init; }

    public override bool Equals(Type? other)
        => other is FunctionType fn
        && fn.Parameters == Parameters
        && object.Equals(fn.Return, Return);
    public override int GetHashCode()
        => HashCode.Combine(Parameters, Return);

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


    public override LLVMValueRef BuildDestructor(RecContext ctx)
        => ctx.EmptyDestructor;
    public override FieldDescriptor[] GetFields(RecContext ctx)
        => [];
    protected override LLVMTypeRef BuildLLVMType(RecContext ctx)
        => LLVMTypeRef.CreateFunction(
            Return?.GetLLVMType(ctx) ?? LLVMTypeRef.Void,
            [.. from p in Parameters select p.GetLLVMType(ctx)]
        );

    public override void PropogateVisitor<V>(V visitor)
    {
        foreach (var param in Parameters)
            visitor.Visit(param);

        if (Return is not null)
            visitor.Visit(Return);
    }
}
