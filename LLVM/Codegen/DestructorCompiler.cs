using LLVMSharp.Interop;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public class DestructorCompiler(LLVMContext ctx)
{
    public LLVMContext CTX { get; } = ctx;
    private readonly Dictionary<RecType, LLVMValueRef> resultCache = [];
    private readonly List<(RecType, LLVMValueRef)> uncompiledDestructors = [];

    public Option<LLVMValueRef> GetDestructor(RecType type)
    {
        if(!resultCache.GetOrInsertDefault(type, out var value))
        {
            var result = ImplementGetDestructor(type);

            if(result.IsNone)
                return result;

            value.Value = result.Unwrap();
        }

        return Option.Some(value.Value);
    }

    private Option<LLVMValueRef> ImplementGetDestructor(RecType type)
    {
        return type switch
        {
            // Complex to compile types
            StructType s => Option.Some(ImplementGetStructDestructor(s)),

            _ => Option.None
        };
    }

    public LLVMTypeRef DestructorType
        => LLVMTypeRef.CreateFunction(
            CTX.LLVM.VoidType,
            [LLVMTypeRef.CreatePointer(CTX.LLVM.VoidType, 0)]
        );

    private LLVMValueRef ImplementGetStructDestructor(StructType type)
    {
        var result = CTX.Module.AddFunction(
            $"{type.FullName}::<destruct>", DestructorType);

        uncompiledDestructors.Add((type, result));
        return result;
    }

    public void CompileDefined()
    {
        foreach(var (type, fn) in uncompiledDestructors)
        {
            if(type is StructType stype)
            {
                ImplementCompileStructDestructor(stype, fn);
            }
            else throw Unimplemented;
        }

        uncompiledDestructors.Clear();
    }

    private void ImplementCompileStructDestructor(StructType type, LLVMValueRef fn)
    {
        var ptr = fn.GetParam(0);

        var entry = CTX.LLVM.AppendBasicBlock(fn, "entry");
        CTX.Builder.PositionAtEnd(entry);

        var dropImplResult = CTX.ReC.TypeAssociations.Search(
            type, Identifier.Builtin.Drop, []);
        
        // If drop implementation is correct signature
        if(dropImplResult.IsOk(out var dropImpl)
        && dropImpl.Type.Return.IsNone
        && dropImpl.HasReceiver
        && dropImpl.Type.Parameters is [ReferenceType { Deref: var inner }]
        && inner == type)
        {
            var dropImplLLVM = CTX.CodeGenerator.GetLLVMFunction(dropImpl);
            CTX.Builder.BuildCall2(DestructorType, dropImplLLVM, [ptr]);
        }

        var fields = type.Fields.Unwrap();
        for(var i = 0; i < fields.Length; i++)
        {
            var fieldDestOpt = GetDestructor(fields[i].Type);

            if(fieldDestOpt.IsSome(out var fieldDest))
            {
                var gep = CTX.Builder.BuildStructGEP2(
                    CTX.TypeCompiler.Compile(type), ptr, (uint)fields[i].Index);
                
                CTX.Builder.BuildCall2(DestructorType, fieldDest, [gep]);
            }
        }

        CTX.Builder.BuildRetVoid();
    }
}