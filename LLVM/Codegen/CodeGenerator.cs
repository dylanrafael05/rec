using System.Net;
using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.IR;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator(LLVMContext ctx)
{
    public LLVMContext CTX { get; } = ctx;

    private Dictionary<Function, LLVMValueRef> LLVMFunctions { get; } = [];
    private Dictionary<InstructionBlock, LLVMBasicBlockRef> LLVMBlocks { get; } = [];
    private Dictionary<ValueID, LLVMValueRef> LLVMValues { get; } = [];

    private IRFunction CurrentFunction
        => CTX.ReC.Functions.Current.UnwrapNull().IRFunction.Unwrap();
    private LLVMValueRef CurrentLLVMFunction 
        => LLVMFunctions[CurrentFunction.Function];

    public void DefineFunction(Function function)
    {
        var type = CTX.TypeCompiler.Compile(function.Type);
        var llvmfn = CTX.Module.AddFunction(function.FullName, type);

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
        var fn = LLVMFunctions[function.Function];

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
    
    private LLVMValueRef USizeLiteral(ulong n)
        => LLVMValueRef.CreateConstInt(
            CTX.TypeCompiler.Compile(CTX.ReC.BuiltinTypes.USize), n
        );
    
    private LLVMValueRef USizeLiteral(int n)
        => USizeLiteral((ulong)n);

    private void GenerateIndexLoop(
        LLVMValueRef minInclusive, LLVMValueRef maxExclusive, 
        Action<LLVMValueRef> loopBody)
    {
        var usizeTy = CTX.TypeCompiler.Compile(CTX.ReC.BuiltinTypes.USize);
        
        var indexPtr = CTX.Builder.BuildAlloca(usizeTy);
        CTX.Builder.BuildStore(minInclusive, indexPtr);

        var condBlock = CurrentLLVMFunction.AppendBasicBlock("");
        var loopBlock = CurrentLLVMFunction.AppendBasicBlock("");
        var endBlock = CurrentLLVMFunction.AppendBasicBlock("");

        // Condition block; loop if (index < arrSize)
        CTX.Builder.BuildBr(condBlock);
        CTX.Builder.PositionAtEnd(condBlock);

        var index = CTX.Builder.BuildLoad2(usizeTy, indexPtr);
        var cmp = CTX.Builder.BuildICmp(LLVMIntPredicate.LLVMIntULT, index, maxExclusive);
        CTX.Builder.BuildCondBr(cmp, loopBlock, endBlock);

        // Loop block; write value to index 
        CTX.Builder.PositionAtEnd(loopBlock);
        loopBody(index);
        var newIndex = CTX.Builder.BuildAdd(index, USizeLiteral(1));
        CTX.Builder.BuildStore(newIndex, indexPtr);
        CTX.Builder.BuildBr(condBlock);

        // End block
        CTX.Builder.PositionAtEnd(endBlock);
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
            InstructionKind.ArrayLiteral array => GenerateArray(array, inst),
            InstructionKind.StringLiteral str => GenerateString(str, inst),
            InstructionKind.StructLiteral str => GenerateStruct(str, inst),
            InstructionKind.Unary un => GenerateUnary(un, inst),
            InstructionKind.Sizeof sz => GenerateSizeof(sz, inst),
            InstructionKind.IndexAddress index => GenerateIndex(index, inst),

            // Special cases; noop and leak have no impact on codegen
            InstructionKind.Noop noop => Option.Some(ValueOf(noop.Value)),
            InstructionKind.Leak leak => Option.Some(ValueOf(leak.Value)),

            _ => throw Unimplemented
        };

        LLVMValues.Add(inst.ValueID.Unwrap(), optval.If(!inst.Type.IsNone).Or(NoneLiteral));
    }
}