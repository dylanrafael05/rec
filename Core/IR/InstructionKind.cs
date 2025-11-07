using Re.C.Definitions;
using Re.C.Syntax;

namespace Re.C.IR;

public abstract record InstructionKind
{
    public virtual void GetJumpBlocks(IList<InstructionBlock> blocks)
    {}

    public record NoneLiteral : InstructionKind
    {
        public override string ToString()
            => "none";
    }

    public record FloatLiteral(double Value) : InstructionKind
    {
        public override string ToString()
            => $"float {Value}";
    }
    public record IntLiteral(UInt128 Value) : InstructionKind
    {
        public override string ToString()
            => $"int {Value}";
    }
    public record StringLiteral(string Value) : InstructionKind
    {
        public override string ToString()
            => $"string \"{Value}\"";
    }
    public record FunctionLiteral(Function Function) : InstructionKind
    {
        public override string ToString()
            => $"function {Function.FullName}";
    }
    public record StructLiteral(ValueID[] Fields) : InstructionKind
    {
        public override string ToString()
            => $"struct [{string.Join(", ", Fields)}]";
    }

    public record Argument(int Index) : InstructionKind
    {
        public override string ToString()
            => $"argument {Index}";
    }

    public record Binary(ValueID LHS, ValueID RHS, BinaryOperator Operator) : InstructionKind
    {
        public override string ToString()
            => $"{LHS} {BinaryOperator.GetRepr(Operator)} {RHS}";
    }
    public record Unary(ValueID Op, UnaryOperator Operator) : InstructionKind
    {
        public override string ToString()
            => $"{UnaryOperator.GetRepr(Operator)} {Op}";
    }
    
    public record Local(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"new local, init {Value}";
    }

    public record FieldPtr(ValueID Ptr, int Index) : InstructionKind
    {
        public override string ToString()
            => $"fieldptr {Ptr} field {Index}";
    }
    public record FieldCopy(ValueID Value, int Index) : InstructionKind
    {
        public override string ToString()
            => $"fieldcp {Value} field {Index}";
    }

    public record Load(ValueID Ptr) : InstructionKind
    {
        public override string ToString()
            => $"load {Ptr}";
    }
    public record Store(ValueID Ptr, ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"store {Ptr} <- {Value}";
    }

    public record Call(ValueID Ptr, ValueID[] Arguments) : InstructionKind
    {
        public override string ToString()
            => $"call {Ptr} with {string.Join(", ", Arguments)}";
    }
    public record BuiltinCast(ValueID Ptr) : InstructionKind
    {
        public override string ToString()
            => $"cast {Ptr}";
    }

    public record Phi(Dictionary<InstructionBlock, ValueID> Incoming) : InstructionKind
    {
        public override string ToString()
            => $"phi {string.Join(", ", from kvp in Incoming select $"{kvp.Key.Name}: {kvp.Value}")}";
    }

    public record Goto(InstructionBlock Target) : InstructionKind
    {
        public override string ToString()
            => $"goto {Target.Name}";


        public override void GetJumpBlocks(IList<InstructionBlock> blocks)
        {
            blocks.Add(Target);
        }
    }
    public record Return(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"return {Value}";
    }
    public record Branch(ValueID Cond, InstructionBlock WhenTrue, InstructionBlock WhenFalse) : InstructionKind
    {
        public override string ToString()
            => $"if {Cond} then {WhenTrue.Name} else {WhenFalse.Name}";
        
        public override void GetJumpBlocks(IList<InstructionBlock> blocks)
        {
            blocks.Add(WhenTrue);
            blocks.Add(WhenFalse);
        }
    }
    
    public record Error : InstructionKind
    {
        public override string ToString()
            => $"error";
    }
}
