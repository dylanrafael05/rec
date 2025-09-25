using LLVMSharp.Interop;
using Re.C.Types.Descriptors;

namespace Re.C.Types;

public abstract class Type
{
    public abstract string Name { get; }
    public abstract string FullName { get; }

    protected abstract LLVMTypeRef BuildLLVMType(ProgramContext ctx);
    public abstract LLVMValueRef BuildDestructor(ProgramContext ctx);
    public abstract FieldDescriptor[] GetFields(ProgramContext ctx);

    public LLVMTypeRef GetLLVMType(ProgramContext ctx)
    {
        if (ctx.TypeCache.TryGetValue(this, out var result))
            return result;

        result = BuildLLVMType(ctx);
        ctx.TypeCache[this] = result;
        
        return result;
    }
}
