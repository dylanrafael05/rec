using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateCast(InstructionKind.BuiltinCast cast, Instruction inst)
    {
        var value = ValueOf(cast.Value);

        var t1 = CurrentFunction.InstructionByValue(cast.Value).Type;
        var t2 = inst.Type;

        var b = CTX.Builder;

        var l1 = CTX.TypeCompiler.Compile(t1);
        var l2 = CTX.TypeCompiler.Compile(t2);

        var s1 = CTX.TargetData.StoreSizeOfType(l1);
        var s2 = CTX.TargetData.StoreSizeOfType(l2);

        // No-op casts //
        if(t1 == t2)
            return Option.Some(value);

        if(t1.IsInteger && t2.IsInteger && s1 == s2)
            return Option.Some(value);

        if(t1 is PointerType or ReferenceType && t2 is PointerType or ReferenceType)
            return Option.Some(value);

        // Meaningful casts //
        return Option.Some((t1, t2) switch
        {
            ({ IsInteger: true }, { IsInteger: true, IsSigned: true }) when s1 < s2
                => b.BuildSExt(value, l2),
            ({ IsInteger: true }, { IsInteger: true, IsSigned: false }) when s1 < s2
                => b.BuildZExt(value, l2),
            
            ({ IsInteger: true }, { IsInteger: true }) when s1 > s2
                => b.BuildTrunc(value, l2),

            ({ IsInteger: true, IsSigned: true }, { IsFloat: true })
                => b.BuildSIToFP(value, l2),
            ({ IsInteger: true, IsSigned: false }, { IsFloat: true })
                => b.BuildUIToFP(value, l2),
                
            ({ IsFloat: true }, { IsInteger: true, IsSigned: true })
                => b.BuildFPToSI(value, l2),
            ({ IsFloat: true }, { IsInteger: true, IsSigned: false })
                => b.BuildFPToUI(value, l2),
                
            ({ IsFloat: true }, { IsFloat: true }) when s1 < s2
                => b.BuildFPExt(value, l2),
            ({ IsFloat: true }, { IsFloat: true }) when s1 > s2
                => b.BuildFPTrunc(value, l2),

            _ => throw Unimplemented  
        });
    }
}