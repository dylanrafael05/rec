using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    public LLVMValueRef GenerateArrayFromParts(ArrayType type, LLVMValueRef ptr, LLVMValueRef size)
    {
        var ty = CTX.TypeCompiler.Compile(type);
        var lptr = CTX.Builder.BuildAlloca(ty);

        CTX.Builder.BuildStore(
            ptr, CTX.Builder.BuildStructGEP2(ty, lptr, TypeCompiler.ArrayPtrIndex));
        
        CTX.Builder.BuildStore(
            size, CTX.Builder.BuildStructGEP2(ty, lptr, TypeCompiler.ArraySizeIndex));
        
        return CTX.Builder.BuildLoad2(ty, lptr);
    }

    private Option<LLVMValueRef> GenerateArray(InstructionKind.ArrayLiteral array, Instruction inst)
    {
        var elemTy = inst.Type.Element.Unwrap();
        var llvmElemTy = CTX.TypeCompiler.Compile(elemTy);
        var arrSize = array.Construction switch
        {
            var x and { MatchesDirect:      true } => USizeLiteral(x.UnwrapAsDirect().Values.Length),
            var x and { MatchesDuplication: true } => ValueOf(x.UnwrapAsDuplication().Count),
            var x and { MatchesRaw:         true } => ValueOf(x.UnwrapAsRaw().Count),

            _ => throw Unimplemented
        };

        var llvmArray = array.Construction switch 
        {
            var x and { MatchesRaw: true } => ValueOf(x.UnwrapAsRaw().Count),
            _                              => CTX.Builder.BuildArrayAlloca(llvmElemTy, arrSize)
        };

        if(array.Construction.IsDirect(out var values))
        {
            foreach(var (val, x) in values.Indexed)
            {
                var ptr = CTX.Builder.BuildGEP2(llvmElemTy, llvmArray, [USizeLiteral(x)]);
                CTX.Builder.BuildStore(ValueOf(val), ptr);
            }
        }
        else if(array.Construction.IsDuplication(out var value, out _))
        {
            var lvalue = ValueOf(value);

            GenerateIndexLoop(
                USizeLiteral(0),
                arrSize,
                i =>
                {
                    var arrIndex = CTX.Builder.BuildInBoundsGEP2(llvmElemTy, llvmArray, [i]);     
                    CTX.Builder.BuildStore(lvalue, arrIndex); 
                }
            );
        }

        return Option.Some(
            GenerateArrayFromParts(inst.Type.UnwrapAs<ArrayType>(), llvmArray, arrSize));
    }
}