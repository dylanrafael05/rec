using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public abstract class Type
{
    public abstract string Name { get; }
    public abstract string FullName { get; }

    protected abstract LLVMTypeRef BuildLLVMType(CodegenContext ctx);
    public abstract LLVMValueRef BuildDestructor(CodegenContext ctx);
    public abstract FieldDescriptor[] GetFields(CodegenContext ctx);

    public LLVMTypeRef GetLLVMType(CodegenContext ctx)
    {
        if (ctx.TypeCache.TryGetValue(this, out var result))
            return result;

        result = BuildLLVMType(ctx);
        ctx.TypeCache[this] = result;
        
        return result;
    }
}
