using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Passes;
using Re.C.Syntax.Resolvers;
using Re.C.Types;
using Re.C.Vocabulary;

namespace Re.C;

// TODO: split this into smaller parts?

/// <summary>
/// The context of a Rec compilation. Includes all LLVM references,
/// all scopes and definitions, and information about builtins.
/// </summary>
public class RecContext
{
    /// <summary>
    /// The LLVM context which compilation occurs in.
    /// </summary>
    public required LLVMContextRef Context { get; init; }
    /// <summary>
    /// The LLVM module where all compiled code resides.
    /// </summary>
    public required LLVMModuleRef Module { get; init; }
    /// <summary>
    /// The LLVM builder pointing into the compiler's module.
    /// </summary>
    public required LLVMBuilderRef Builder { get; init; }
    /// <summary>
    /// A reference to the target information used by LLVM.
    /// </summary>
    public required LLVMTargetDataRef TargetData { get; init; }

    /// <summary>
    /// A reference to the empty destructor function.
    /// </summary>
    public LLVMValueRef EmptyDestructor { get; init; }
    /// <summary>
    /// A cache mapping between Rec types and their LLVM-compiled
    /// counterparts.
    /// </summary>
    public Dictionary<Types.Type, LLVMTypeRef> TypeCache { get; } = [];

    /// <summary>
    /// A reference to all the builtin types.
    /// </summary>
    public required BuiltinTypes BuiltinTypes { get; init; }

    /// <summary>
    /// The global scope of this compilation.
    /// </summary>
    public required Scope GlobalScope { get; init; }

    /// <summary>
    /// The function within which compilation is currently taking place.
    /// </summary>
    public Function? CurrentFunction { get; set; }
    /// <summary>
    /// The current scope at this point in the compilation.
    /// This will be updated as syntax is resolved and compiled.
    /// </summary>
    public required Scope CurrentScope { get; set; }
    /// <summary>
    /// The current source being compiled.
    /// </summary>
    public Source? CurrentSource { get; set; }
    /// <summary>
    /// A reference to the list of all imported scopes for the
    /// currently active source.
    /// </summary>
    public List<Scope> CurrentImports
    {
        get
        {
            if (!ImportsBySource.TryGetValue(CurrentSource.UnwrapNull(), out var result))
            {
                result = [];
                ImportsBySource.Add(CurrentSource!, result);
            }

            return result;
        }
    }

    /// <summary>
    /// A stack storing all scopes as they are superceded.
    /// </summary>
    public Stack<Scope> ScopeStack { get; } = [];

    /// <summary>
    /// The diagnostic bag used for compilation. All diagnostics
    /// should be placed here.
    /// </summary>
    public DiagnosticBag Diagnostics { get; } = [];
    /// <summary>
    /// A mapping of sources to the scopes that they import.
    /// </summary>
    public Dictionary<Source, List<Scope>> ImportsBySource { get; } = [];

    /// <summary>
    /// A reference to all passes for this context.
    /// </summary>
    public RecPasses Passes { get; }
    /// <summary>
    /// A reference to all the resolvers for this context.
    /// </summary>
    public RecResolvers Resolvers { get; }

    private RecContext()
    {
        Passes = new()
        {
            FileDeclarations = new(this),
            TypeDeclarations = new(this),
            FunctionDeclarations = new(this),
            TypeDefinitions = new(this),
            FunctionDefinitions = new(this)
        };

        Resolvers = new()
        {
            Type = new(this),
            Syntax = new(this)
        };
    }

    /// <summary>
    /// Change the current scope to the one provided.
    /// </summary>
    public void EnterScope(Scope scope)
    {
        ScopeStack.Push(CurrentScope);
        CurrentScope = scope;
    }

    /// <summary>
    /// Return the current scope to what it was before the
    /// matching call to EnterScope().
    /// </summary>
    public void ExitScope()
    {
        CurrentScope = ScopeStack.Pop();
    }

    /// <summary>
    /// Create a new RecContext. Properly assigns all required fields.
    /// This function should only be called once per compiler instance
    /// (not once per source compiled).
    /// </summary>
    public static RecContext Create(
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
            Identifier = Identifier.None,
            Parent = null
        };

        var module = llvmContext.CreateModuleWithName(moduleName);
        var builder = llvmContext.CreateBuilder();

        Types.Type MakePrimitive(LLVMTypeRef type, string name, PrimitiveType.Class cls)
            => scope.Define(new PrimitiveType(type, cls) { Identifier = Identifier.Name(name) }).UnwrapNull();

        var types = new BuiltinTypes
        {
            Error = new ErrorType(),
            None = scope.Define(new NoneType { Identifier = Identifier.Name("none") }).UnwrapNull(),

            Bool = MakePrimitive(llvmContext.Int1Type, "bool", PrimitiveType.Class.Other),
            I8 = MakePrimitive(llvmContext.Int8Type, "i8", PrimitiveType.Class.SignedInt),
            I16 = MakePrimitive(llvmContext.Int16Type, "i16", PrimitiveType.Class.SignedInt),
            I32 = MakePrimitive(llvmContext.Int32Type, "i32", PrimitiveType.Class.SignedInt),
            I64 = MakePrimitive(llvmContext.Int64Type, "i64", PrimitiveType.Class.SignedInt),
            ISize = MakePrimitive(llvmContext.GetIntPtrType(targetData), "isize", PrimitiveType.Class.SignedInt),
            U8 = MakePrimitive(llvmContext.Int8Type, "u8", PrimitiveType.Class.UnsignedInt),
            U16 = MakePrimitive(llvmContext.Int16Type, "u16", PrimitiveType.Class.UnsignedInt),
            U32 = MakePrimitive(llvmContext.Int32Type, "u32", PrimitiveType.Class.UnsignedInt),
            U64 = MakePrimitive(llvmContext.Int64Type, "u64", PrimitiveType.Class.UnsignedInt),
            USize = MakePrimitive(llvmContext.GetIntPtrType(targetData), "usize", PrimitiveType.Class.UnsignedInt),
            F32 = MakePrimitive(llvmContext.FloatType, "f32", PrimitiveType.Class.Float),
            F64 = MakePrimitive(llvmContext.DoubleType, "f64", PrimitiveType.Class.Float),
        };

        var emptyDestructor = module.AddFunction(
            "__empty_destructor",
            LLVMTypeRef.CreateFunction(LLVMTypeRef.Void, [LLVMTypeRef.CreatePointer(LLVMTypeRef.Void, 0)]));

        // TODO: this crashes. make it not crash
        // builder.PositionAtEnd(emptyDestructor.EntryBasicBlock);
        // builder.BuildRetVoid();
        // builder.ClearInsertionPosition();

        return new()
        {
            Context = llvmContext,
            Module = module,
            Builder = builder,
            TargetData = targetData,

            GlobalScope = scope,
            CurrentScope = scope,
            BuiltinTypes = types,

            EmptyDestructor = emptyDestructor,
        };
    }
}