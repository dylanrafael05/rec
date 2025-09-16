using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C;

public class CodegenContext
{
    public required LLVMContextRef Context { get; init; }
    public required LLVMModuleRef Module { get; init; }
    public required LLVMBuilderRef Builder { get; init; }
    public required LLVMTargetDataRef TargetData { get; init; }

    public LLVMValueRef EmptyDestructor { get; init; }
    public Dictionary<Types.Type, LLVMTypeRef> TypeCache { get; } = [];

    public required Scope GlobalScope { get; init; }
    public required BuiltinTypes BuiltinTypes { get; init; }

    public static CodegenContext Create(
        LLVMContextRef llvmContext,
        string moduleName)
    {
        LLVM.InitializeNativeTarget();

        var target = LLVMTargetRef.GetTargetFromTriple(LLVMTargetRef.DefaultTriple);
        var machine = target.CreateTargetMachine(
            LLVMTargetRef.DefaultTriple,
            "",
            "",
            LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault,
            LLVMRelocMode.LLVMRelocDefault,
            LLVMCodeModel.LLVMCodeModelDefault);

        var targetData = machine.CreateTargetDataLayout();

        var scope = new Scope
        {
            Identifier = Identifier.FromTempID(0),
            Parent = null
        };

        var module = llvmContext.CreateModuleWithName(moduleName);
        var builder = llvmContext.CreateBuilder();

        Types.Type MakePrimitive(LLVMTypeRef type, string name)
            => scope.Define(new PrimitiveType(type) { Identifier = name })!;

        var types = new BuiltinTypes
        {
            Bool = MakePrimitive(llvmContext.Int1Type, "bool"),
            I8 = MakePrimitive(llvmContext.Int8Type, "i8"),
            I16 = MakePrimitive(llvmContext.Int16Type, "i16"),
            I32 = MakePrimitive(llvmContext.Int32Type, "i32"),
            I64 = MakePrimitive(llvmContext.Int64Type, "i64"),
            ISize = MakePrimitive(llvmContext.GetIntPtrType(targetData), "isize"),
            U8 = MakePrimitive(llvmContext.Int8Type, "u8"),
            U16 = MakePrimitive(llvmContext.Int16Type, "u16"),
            U32 = MakePrimitive(llvmContext.Int32Type, "u32"),
            U64 = MakePrimitive(llvmContext.Int64Type, "u64"),
            USize = MakePrimitive(llvmContext.GetIntPtrType(targetData), "usize"),
            F32 = MakePrimitive(llvmContext.FloatType, "f32"),
            F64 = MakePrimitive(llvmContext.DoubleType, "f64"),
        };

        var emptyDestructor = module.AddFunction(
            "__empty_destructor",
            LLVMTypeRef.CreateFunction(LLVMTypeRef.Void, [LLVMTypeRef.CreatePointer(LLVMTypeRef.Void, 0)]));

        builder.PositionAtEnd(emptyDestructor.EntryBasicBlock);
        builder.BuildRetVoid();
        builder.ClearInsertionPosition();

        return new()
        {
            Context = llvmContext,
            Module = module,
            Builder = builder,
            TargetData = targetData,

            GlobalScope = scope,
            BuiltinTypes = types,

            EmptyDestructor = emptyDestructor,
        };
    }
}