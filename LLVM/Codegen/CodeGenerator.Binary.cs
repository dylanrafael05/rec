using LLVMSharp.Interop;
using Re.C.IR;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.LLVM.Codegen;

public partial class CodeGenerator
{
    private Option<LLVMValueRef> GenerateBinary(InstructionKind.Binary bin, Instruction inst)
    {
        var lhs = ValueOf(bin.LHS);
        var rhs = ValueOf(bin.RHS);

        var t1 = CurrentFunction.InstructionByValue(bin.LHS).Type;
        var t2 = CurrentFunction.InstructionByValue(bin.RHS).Type;
        var b = CTX.Builder;

        return Option.Some(bin.Operator switch
        {
            // Arithmetic operators //
            BinaryOperator.Add => (t1, t2) switch 
            {
                ({ IsInteger: true }, _) 
                    => b.BuildAdd(lhs, rhs),
                
                ({ IsFloat: true }, _) 
                    => b.BuildFAdd(lhs, rhs),
                
                (PointerType { Pointee: var p }, { IsInteger: true })
                    => b.BuildGEP2(CTX.TypeCompiler.Compile(p), lhs, [rhs]),

                _ => throw Unimplemented,
            },

            BinaryOperator.Subtract => (t1, t2) switch 
            {
                ({ IsInteger: true }, _) 
                    => b.BuildSub(lhs, rhs),
                
                ({ IsFloat: true }, _) 
                    => b.BuildFSub(lhs, rhs),
                
                (PointerType { Pointee: var p }, { IsInteger: true, IsSigned: true })
                    => b.BuildGEP2(CTX.TypeCompiler.Compile(p), lhs, [b.BuildNeg(rhs)]),

                _ => throw Unimplemented,
            },
            
            BinaryOperator.Multiply => (t1, t2) switch 
            {
                ({ IsInteger: true }, _) 
                    => b.BuildMul(lhs, rhs),
                
                ({ IsFloat: true }, _) 
                    => b.BuildFMul(lhs, rhs),

                _ => throw Unimplemented,
            },
            
            BinaryOperator.Divide => (t1, t2) switch 
            {
                ({ IsInteger: true, IsSigned: true }, _) 
                    => b.BuildSDiv(lhs, rhs),
                    
                ({ IsInteger: true, IsSigned: false }, _) 
                    => b.BuildUDiv(lhs, rhs),
                
                ({ IsFloat: true }, _) 
                    => b.BuildFDiv(lhs, rhs),

                _ => throw Unimplemented,
            },
            
            BinaryOperator.Modulo => (t1, t2) switch 
            {
                ({ IsInteger: true, IsSigned: true }, _) 
                    => b.BuildSRem(lhs, rhs),
                    
                ({ IsInteger: true, IsSigned: false }, _) 
                    => b.BuildURem(lhs, rhs),
                
                ({ IsFloat: true }, _) 
                    => b.BuildFRem(lhs, rhs),

                _ => throw Unimplemented,
            },

            // Comparison operators //
            BinaryOperator.CompEq => (t1, t2) switch
            {
                ({ IsInteger: true } or { IsBool: true } or PointerType, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntEQ, lhs, rhs),
                    
                ({ IsFloat: true }, _)
                    => b.BuildFCmp(LLVMRealPredicate.LLVMRealOEQ, lhs, rhs),

                _ => throw Unimplemented
            },

            BinaryOperator.CompNe => (t1, t2) switch
            {
                ({ IsInteger: true } or { IsBool: true } or PointerType, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntNE, lhs, rhs),
                    
                ({ IsFloat: true }, _)
                    => b.BuildFCmp(LLVMRealPredicate.LLVMRealONE, lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.CompLe => (t1, t2) switch
            {
                ({ IsInteger: true, IsSigned: false } or { IsBool: true } or PointerType, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntULT, lhs, rhs),
                    
                ({ IsInteger: true, IsSigned: true }, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntSLT, lhs, rhs),
                    
                ({ IsFloat: true }, _)
                    => b.BuildFCmp(LLVMRealPredicate.LLVMRealOLT, lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.CompLEq => (t1, t2) switch
            {
                ({ IsInteger: true, IsSigned: false } or { IsBool: true } or PointerType, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntULE, lhs, rhs),
                    
                ({ IsInteger: true, IsSigned: true }, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntSLE, lhs, rhs),
                    
                ({ IsFloat: true }, _)
                    => b.BuildFCmp(LLVMRealPredicate.LLVMRealOLE, lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.CompGr => (t1, t2) switch
            {
                ({ IsInteger: true, IsSigned: false } or { IsBool: true } or PointerType, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntUGT, lhs, rhs),
                    
                ({ IsInteger: true, IsSigned: true }, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntSGT, lhs, rhs),
                    
                ({ IsFloat: true }, _)
                    => b.BuildFCmp(LLVMRealPredicate.LLVMRealOGT, lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.CompGEq => (t1, t2) switch
            {
                ({ IsInteger: true, IsSigned: false } or { IsBool: true } or PointerType, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntUGT, lhs, rhs),
                    
                ({ IsInteger: true, IsSigned: true }, _)
                    => b.BuildICmp(LLVMIntPredicate.LLVMIntSGT, lhs, rhs),
                    
                ({ IsFloat: true }, _)
                    => b.BuildFCmp(LLVMRealPredicate.LLVMRealOGT, lhs, rhs),

                _ => throw Unimplemented
            },

            // Bitwise operators //
            BinaryOperator.BitLeft => (t1, t2) switch
            {
                ({ IsInteger: true }, _)
                    => b.BuildShl(lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.BitRight => (t1, t2) switch
            {
                ({ IsInteger: true }, _)
                    => b.BuildLShr(lhs, rhs),

                _ => throw Unimplemented
            },

            BinaryOperator.BitAnd => (t1, t2) switch
            {
                ({ IsInteger: true } or { IsBool: true }, _)
                    => b.BuildAnd(lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.BitOr => (t1, t2) switch
            {
                ({ IsInteger: true } or { IsBool: true }, _)
                    => b.BuildOr(lhs, rhs),

                _ => throw Unimplemented
            },
            
            BinaryOperator.BitXor => (t1, t2) switch
            {
                ({ IsInteger: true } or { IsBool: true }, _)
                    => b.BuildXor(lhs, rhs),

                _ => throw Unimplemented
            },

            // Base case //
            _ => throw Unimplemented

        });
    }
}