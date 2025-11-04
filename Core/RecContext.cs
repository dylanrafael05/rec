using LLVMSharp.Interop;
using Re.C.Compilation;
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
    public LLVMContextRef LLVM { get; }
    /// <summary>
    /// The LLVM module where all compiled code resides.
    /// </summary>
    public LLVMModuleRef Module { get; }
    /// <summary>
    /// The LLVM builder pointing into the compiler's module.
    /// </summary>
    public LLVMBuilderRef Builder { get; }
    /// <summary>
    /// A reference to the target information used by LLVM.
    /// </summary>
    public LLVMTargetDataRef TargetData { get; }
    /// <summary>
    /// A reference to the target machine information used by LLVM.
    /// </summary>
    public LLVMTargetMachineRef TargetMachine { get; }

    /// <summary>
    /// A reference to the empty destructor function.
    /// </summary>
    public LLVMValueRef EmptyDestructor { get; }
    /// <summary>
    /// A cache mapping between Rec types and their LLVM-compiled
    /// counterparts.
    /// </summary>
    public Dictionary<Types.Type, LLVMTypeRef> TypeCache { get; } = [];

    /// <summary>
    /// A reference to all the builtin types.
    /// </summary>
    public BuiltinTypes BuiltinTypes { get; }

    /// <summary>
    /// The global scope of this compilation.
    /// </summary>
    public Scope GlobalScope { get; }

    /// <summary>
    /// The current source being compiled.
    /// </summary>
    public Source? CurrentSource { get; set; }
    /// <summary>
    /// A reference to the list of all imported scopes for the
    /// currently active source.
    /// </summary>
    public IReadOnlyCollection<Scope> CurrentImports => ImportsBySource.GetValueOrDefault(CurrentSource!) ?? [];

    /// <summary>
    /// Provided a view of the current LLVM function, or panics
    /// if there is no such function.
    /// </summary>
    public LLVMValueRef CurrentLLVMFunction => 
        Functions.Current.UnwrapNull().LLVMFunction.Unwrap();

    /// <summary>
    /// A stack storing all scopes as they are superceded.
    /// </summary>
    public Scoped<Scope> Scopes { get; }
    /// <summary>
    /// A stack storing all functions as they are superceded.
    /// </summary>
    public Scoped<Function?> Functions { get; } = new(null);
    /// <summary>
    /// The object which tracks the associations between types and methods.
    /// </summary>
    public TypeAssociations TypeAssociations { get; } = new();

    /// <summary>
    /// The diagnostic bag used for compilation. All diagnostics
    /// should be placed here.
    /// </summary>
    public DiagnosticBag Diagnostics { get; } = [];
    /// <summary>
    /// A mapping of sources to the scopes that they import.
    /// </summary>
    public MultiDictionary<Source, Scope> ImportsBySource { get; } = [];

    /// <summary>
    /// A reference to all passes for this context.
    /// </summary>
    public RecPasses Passes { get; }
    /// <summary>
    /// A reference to all the resolvers for this context.
    /// </summary>
    public RecResolvers Resolvers { get; }
    /// <summary>
    /// An instance of the syntax compiler.
    /// </summary>
    public SyntaxCompiler SyntaxCompiler { get; }

    private RecContext(
        LLVMContextRef llvmContext,
        string moduleName)
    {
        LLVMSharp.Interop.LLVM.InitializeNativeTarget();

        var target = LLVMTargetRef.GetTargetFromTriple(LLVMTargetRef.DefaultTriple);
        var machine = target.CreateTargetMachine(
            LLVMTargetRef.DefaultTriple,
            "generic",
            "",
            LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault,
            LLVMRelocMode.LLVMRelocPIC,
            LLVMCodeModel.LLVMCodeModelDefault);

        var targetData = machine.CreateTargetDataLayout();

        var scope = new Scope
        {
            CTX = this,
            Identifier = Identifier.None,
            Parent = null
        };

        var module = llvmContext.CreateModuleWithName(moduleName);
        var builder = llvmContext.CreateBuilder();

        Types.Type MakePrimitive(LLVMTypeRef type, string name, PrimitiveType.Class cls)
            => scope.Define(new PrimitiveType(type, cls) { 
                Identifier = Identifier.Name(name), 
                DefinitionLocation = Option.None }).UnwrapNull();

        var types = new BuiltinTypes
        {
            Error = new ErrorType(),
            None = scope.Define(new NoneType { 
                Identifier = Identifier.Name("none"), 
                DefinitionLocation = Option.None }).UnwrapNull(),

            Bool = MakePrimitive(llvmContext.Int1Type, "bool", PrimitiveType.Class.Bool),
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

        Passes = new()
        {
            FileDeclarations = new(this),
            FileUsages = new(this),
            TypeDeclarations = new(this),
            FunctionDeclarations = new(this),
            TypeDefinitions = new(this),
            FunctionDefinitions = new(this),
            LLVMGeneration = new(this),
        };

        Resolvers = new()
        {
            Type = new(this),
            Syntax = new(this)
        };

        SyntaxCompiler = new(this);

        LLVM = llvmContext;
        Module = module;
        Builder = builder;
        TargetData = targetData;

        GlobalScope = scope;
        Scopes = new(scope);
        BuiltinTypes = types;
    }

    /// <summary>
    /// Create a new RecContext. Properly assigns all required fields.
    /// This function should only be called once per compiler instance
    /// (not once per source compiled).
    /// </summary>
    public static RecContext Create(
        LLVMContextRef llvmContext,
        string moduleName)
        => new(llvmContext, moduleName);
}