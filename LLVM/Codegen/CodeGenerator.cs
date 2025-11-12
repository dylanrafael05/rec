using System.Net;
using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator(LLVMContext ctx)
{
    public LLVMContext CTX { get; } = ctx;

    private Dictionary<IRFunction, LLVMValueRef> LLVMFunctions { get; } = [];
    private Dictionary<InstructionBlock, LLVMBasicBlockRef> LLVMBlocks { get; } = [];
    private Dictionary<ValueID, LLVMValueRef> LLVMValues { get; } = [];

    private IRFunction CurrentFunction
        => CTX.ReC.Functions.Current.UnwrapNull().IRFunction.Unwrap();
    private LLVMValueRef CurrentLLVMFunction 
        => LLVMFunctions[CurrentFunction];

    public void DefineFunction(IRFunction function)
    {
        var type = CTX.TypeCompiler.Compile(function.Function.Type);
        var llvmfn = CTX.Module.AddFunction(function.Function.FullName, type);

        LLVMFunctions.Add(function, llvmfn);
    }

    public void GenerateFunction(IRFunction function)
    {
        // External functions need not be realized //
        if (function.Function.IsExternal)
            return;

        // Clear previously cached block and value mappings //
        LLVMBlocks.Clear();
        LLVMValues.Clear();
        var fn = LLVMFunctions[function];

        // Set up the context state //
        CTX.ReC.Functions.Enter(function.Function);

        // Create a new basic block for each instruction block in the source function //
        foreach(var block in function.Blocks)
        {
            LLVMBlocks.Add(block, fn.AppendBasicBlock(block.Name));
        }

        // Then, generate each code block //
        using var visited = Temporary.HashSet<InstructionBlock>();
        Visit(visited.Value, function.EntryBlock);

        // Restore the context state //
        CTX.ReC.Functions.Exit();
    }

    private void Visit(HashSet<InstructionBlock> visited, InstructionBlock block)
    {
        if(visited.Contains(block))
            return;

        visited.Add(block);

        foreach(var antecedent in block.Antecedents)
            Visit(visited, antecedent);

        var llvmBlock = LLVMBlocks[block];
            
        CTX.Builder.ClearInsertionPosition();
        CTX.Builder.PositionAtEnd(llvmBlock);

        foreach(var instruction in block.Instructions)
            GenerateInstruction(instruction);
        
        foreach(var consequent in block.Consequents)
            Visit(visited, consequent);
    }

    private LLVMValueRef ValueOf(ValueID id)
        => LLVMValues[id];
    private LLVMBasicBlockRef BlockOf(InstructionBlock block)
        => LLVMBlocks[block];

    private LLVMValueRef NoneLiteral
        => LLVMValueRef.CreateConstStruct([], true);

    private void GenerateInstruction(Instruction inst)
    {
        var optval = inst.Kind switch
        {
            InstructionKind.Argument arg => GenerateArg(arg, inst),
            InstructionKind.Binary bin => GenerateBinary(bin, inst),
            InstructionKind.Branch br => GenerateBranch(br, inst),
            InstructionKind.BuiltinCast cast => GenerateCast(cast, inst),
            InstructionKind.Call call => GenerateCall(call, inst),
            InstructionKind.FieldCopy fc => GenerateFieldCopy(fc, inst),
            InstructionKind.FieldPtr fp => GenerateFieldPtr(fp, inst),
            InstructionKind.FloatLiteral flt => GenerateFloat(flt, inst),
            InstructionKind.FunctionLiteral fn => GenerateFn(fn, inst),
            InstructionKind.Goto gt => GenerateGoto(gt, inst),
            InstructionKind.IntLiteral intl => GenerateInt(intl, inst),
            InstructionKind.Load load => GenerateLoad(load, inst),
            InstructionKind.Local local => GenerateLocal(local, inst),
            InstructionKind.NoneLiteral none => GenerateNone(none, inst),
            InstructionKind.Phi phi => GeneratePhi(phi, inst),
            InstructionKind.Return ret => GenerateReturn(ret, inst),
            InstructionKind.Store store => GenerateStore(store, inst),
            InstructionKind.StringLiteral str => GenerateString(str, inst),
            InstructionKind.StructLiteral str => GenerateStruct(str, inst),
            InstructionKind.Unary un => GenerateUnary(un, inst),

            InstructionKind.Leak leak => Option.Some(ValueOf(leak.Value)),

            _ => throw Unimplemented
        };

        LLVMValues.Add(inst.ValueID.Unwrap(), optval.If(!inst.Type.IsNone).Or(NoneLiteral));
    }
}