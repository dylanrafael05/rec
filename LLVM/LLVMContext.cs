using System.Text;
using LLVMSharp.Interop;
using Re.C.LLVM.Codegen;
using Re.C.LLVM.Passes;
using Re.C.Passes;

namespace Re.C.LLVM;

public class LLVMContext
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
    /// The list of all LLVM-related passes
    /// </summary>
    public PassList DefaultPasses { get; }

    /// <summary>
    /// A reference to the type compiler
    /// </summary>
    public TypeCompiler TypeCompiler { get; }
    /// <summary>
    /// A reference to the code generator
    /// </summary>
    public CodeGenerator CodeGenerator { get; }

    /// <summary>
    /// A reference to the containing ReC context
    /// </summary>
    public RecContext ReC { get; }

    private LLVMContext(
        string moduleName,
        RecContext rec)
    {
        LLVM = LLVMContextRef.Create();
        
        LLVM_Api.InitializeAllTargets();
        LLVM_Api.InitializeAllTargetInfos();
        LLVM_Api.InitializeAllTargetMCs();
        LLVM_Api.InitializeAllAsmParsers();
        LLVM_Api.InitializeAllAsmPrinters();

        var target = LLVMTargetRef.GetTargetFromTriple(LLVMTargetRef.DefaultTriple);
        TargetMachine = target.CreateTargetMachine(
            LLVMTargetRef.DefaultTriple,
            "generic",
            "",
            LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault,
            LLVMRelocMode.LLVMRelocDefault,
            LLVMCodeModel.LLVMCodeModelDefault);

        TargetData = TargetMachine.CreateTargetDataLayout();

        Module = LLVM.CreateModuleWithName(moduleName);
        Builder = LLVM.CreateBuilder();

        unsafe
        {
            using var triple = new MarshaledString(LLVMTargetRef.DefaultTriple);
            var datalayout = LLVM_Api.CopyStringRepOfTargetData(TargetData);

            LLVM_Api.SetTarget(Module, triple);
            LLVM_Api.SetDataLayout(Module, datalayout);

            LLVM_Api.DisposeMessage(datalayout);
        }

        ReC = rec;

        TypeCompiler = new(this);
        CodeGenerator = new(this);

        DefaultPasses = new([
            new DeclarationsPass(this),
            new DefinitionsPass(this),
        ]);
    }

    public static LLVMContext Create(RecContext ctx, string moduleName = "default_module")
        => new(moduleName, ctx);

    public void CompileAll(string outfile)
    {
        ReC.AnalyzeAll();

        if(!ReC.Diagnostics.AnyErrors)
        {
            ReC.ExecutePasses(DefaultPasses);
        }

        unsafe
        {
            LLVMPassBuilderOptionsRef options = LLVM_Api.CreatePassBuilderOptions();

            options.SetVerifyEach(true);
            options.SetCallGraphProfile(true);
            options.SetInlinerThreshold(10);
            options.SetLoopVectorization(true);
            options.SetLoopUnrolling(true);
            options.SetLoopInterleaving(true);
            options.SetSLPVectorization(true);

            using var str = new MarshaledString("default<O2>");
            var error = LLVM_Api.RunPasses(Module, str, TargetMachine, options);

            LLVM_Api.CantFail(error);

            TargetMachine.EmitToFile(
                Module, outfile, LLVMCodeGenFileType.LLVMObjectFile);
        }
    }
}
