using LLVMSharp.Interop;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public class TypeCompiler(LLVMContext ctx)
{
    public LLVMContext CTX { get; } = ctx;
    private readonly Dictionary<RecType, LLVMTypeRef> resultCache = [];

    public LLVMTypeRef Compile(RecType type)
    {
        if(!resultCache.GetOrInsertDefault(type, out var value))
        {
            value.Value = ImplementCompile(type);
        }

        return value.Value;
    }

    private LLVMTypeRef ImplementCompile(RecType type)
    {
        return type switch
        {
            // Simple to compile types
            NoneType => CTX.LLVM.VoidType,
            PointerType => LLVMTypeRef.CreatePointer(CTX.LLVM.VoidType, 0),

            // Complex to compile types
            FunctionType f => ImplementCompileFunction(f),
            StructType s => ImplementCompileStruct(s),
            PrimitiveType p => ImplementCompilePrimitive(p),

            _ => throw Unimplemented
        };
    }

    private LLVMTypeRef ImplementCompileFunction(FunctionType type)
    {
        return LLVMTypeRef.CreateFunction(
            Compile(type.Return),
            [.. from p in type.Parameters select Compile(p)]
        );
    }

    private LLVMTypeRef ImplementCompileStruct(StructType type)
    {
        var ltype = CTX.LLVM.CreateNamedStruct(type.FullName); /* TODO: mangling */
        ltype.StructSetBody(
            [..from f in type.Fields.UnwrapNull() select Compile(f.Type)], 
            false);

        return ltype;
    }

    private LLVMTypeRef ImplementCompilePrimitive(PrimitiveType type)
    {
        return type.Name switch
        {
            "i8" or "u8" => CTX.LLVM.Int8Type,
            "i16" or "u16" => CTX.LLVM.Int16Type,
            "i32" or "u32" => CTX.LLVM.Int32Type,
            "i64" or "u64" => CTX.LLVM.Int64Type,
            "isize" or "usize" => CTX.LLVM.GetIntPtrType(CTX.TargetData),

            "f32" => CTX.LLVM.FloatType,
            "f64" => CTX.LLVM.DoubleType,

            "bool" => CTX.LLVM.Int1Type,

            _ => throw Unimplemented
        };
    }
}