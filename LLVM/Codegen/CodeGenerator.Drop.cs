using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateDrop(InstructionKind.Drop drop, Instruction inst)
    {
        if(drop.Named)
        {
            var falseBlock = CTX.LLVM.AppendBasicBlock(CurrentLLVMFunction, "");
            var endBlock = CTX.LLVM.AppendBasicBlock(CurrentLLVMFunction, "");

            var flagPtr = NamedDropFlags[drop.Value];
            var flag = CTX.Builder.BuildLoad2(CTX.LLVM.Int1Type, flagPtr);

            CTX.Builder.BuildCondBr(flag, endBlock, falseBlock);

            CTX.Builder.PositionAtEnd(falseBlock);
            CTX.Builder.BuildStore(
                LLVMValueRef.CreateConstInt(CTX.LLVM.Int1Type, 1),
                flagPtr);

            GenerateDropInner(drop, inst);

            CTX.Builder.BuildBr(endBlock);
            CTX.Builder.PositionAtEnd(endBlock);
        }
        else
        {
            GenerateDropInner(drop, inst);
        }

        return Option.None;
    }

    private void GenerateDropInner(InstructionKind.Drop drop, Instruction inst)
    {
        var dropVal = CurrentFunction.InstructionByValue(drop.Value);
        var destructorType = drop.Method switch
        {
            DropMethod.Direct => dropVal.Type,
            DropMethod.ThroughPointer => dropVal.Type.Deref.Unwrap(),
            DropMethod.ThroughArray => dropVal.Type.Element.Unwrap(),

            _ => throw Unreachable
        };

        var destructor = CTX.DestructorCompiler
            .GetDestructor(destructorType)
            .Unwrap();

        var val = ValueOf(drop.Value);

        if(drop.Method is DropMethod.Direct)
        {
            var ptr = CTX.Builder.BuildAlloca(CTX.TypeCompiler.Compile(destructorType));
            CTX.Builder.BuildStore(val, ptr);
            CTX.Builder.BuildCall2(
                CTX.DestructorCompiler.DestructorType, destructor, [ptr]);
        }
        else if(drop.Method is DropMethod.ThroughPointer)
        {
            CTX.Builder.BuildCall2(
                CTX.DestructorCompiler.DestructorType, destructor, [val]);
        }
        else if(drop.Method is DropMethod.ThroughArray)
        {
            var aptr = CTX.Builder.BuildExtractValue(
                val, TypeCompiler.ArrayPtrIndex);
            
            GenerateIndexLoop(
                USizeLiteral(0), 
                CTX.Builder.BuildExtractValue(val, TypeCompiler.ArraySizeIndex),
                i =>
                {
                    var eptr = CTX.Builder.BuildGEP2(
                        CTX.TypeCompiler.Compile(destructorType), aptr, [i]);
                    
                    CTX.Builder.BuildCall2(
                        CTX.DestructorCompiler.DestructorType, destructor, [eptr]);
                });
        }
        else throw Unimplemented;
    }
}