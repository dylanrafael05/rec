using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public abstract record InstructionKind
{
    public virtual void GetJumpBlocks(IList<InstructionBlock> blocks)
    {}
    public virtual void GetArguments(IList<ValueID> values)
    {}
    public virtual bool IsTerminal => false;

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
        public override void GetArguments(IList<ValueID> values)
        {
            foreach(var f in Fields)
                values.Add(f);
        }
    }
    public record Sizeof(RecType Type) : InstructionKind
    {
        public override string ToString()
            => $"sizeof {Type}";
    }

    /// <summary>
    /// "noop" is mostly used to signal that a no-op but meaningful operation has taken place,
    /// like a cast from a pointer to a reference.
    /// </summary>
    public record Noop(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"{Value}";

        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Value);
        }
    }
    
    /// <summary>
    /// "leak" is a special instruction which signals that the value returned by this
    /// instruction can be moved from multiple times (that is, the value is 'leaked' from
    /// the perspective of the move checker). It is used to implement the 'break' expression
    /// syntax.
    /// </summary>
    public record Leak(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"leak {Value}";

        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Value);
        }
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
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(LHS);
            values.Add(RHS);
        }
    }
    public record Unary(ValueID Op, UnaryOperator Operator) : InstructionKind
    {
        public override string ToString()
            => $"{UnaryOperator.GetRepr(Operator)} {Op}";
            
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Op);
        }
    }
    public record Local(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"new local, init {Value}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Value);
        }
    }

    public record FieldPtr(ValueID Ptr, int Index) : InstructionKind
    {
        public override string ToString()
            => $"fieldptr {Ptr} field {Index}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Ptr);
        }
    }
    public record FieldCopy(ValueID Value, int Index) : InstructionKind
    {
        public override string ToString()
            => $"fieldcp {Value} field {Index}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Value);
        }
    }

    public record Load(ValueID Ptr) : InstructionKind
    {
        public override string ToString()
            => $"load {Ptr}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Ptr);
        }
    }
    public record Store(ValueID Ptr, ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"store {Ptr} <- {Value}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Ptr);
            values.Add(Value);
        }
    }

    public record Call(ValueID TargetPtr, ValueID[] Arguments) : InstructionKind
    {
        public override string ToString()
            => $"call {TargetPtr} with {string.Join(", ", Arguments)}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(TargetPtr);
            foreach(var f in Arguments)
                values.Add(f);
        }
    }
    public record BuiltinCast(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"cast {Value}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Value);
        }
    }

    public record Phi(Dictionary<InstructionBlock, ValueID> Incoming) : InstructionKind
    {
        public override string ToString()
            => $"phi {string.Join(", ", from kvp in Incoming select $"{kvp.Key.Name}: {kvp.Value}")}";
        
        public override void GetArguments(IList<ValueID> values)
        {
            foreach(var i in Incoming.Values)
                values.Add(i);
        }
    }

    public record Goto(InstructionBlock Target) : InstructionKind
    {
        public override string ToString()
            => $"goto {Target.Name}";


        public override void GetJumpBlocks(IList<InstructionBlock> blocks)
        {
            blocks.Add(Target);
        }

        public override bool IsTerminal => true;
    }
    public record Return(ValueID Value) : InstructionKind
    {
        public override string ToString()
            => $"return {Value}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Value);
        }

        public override bool IsTerminal => true;
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
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Cond);
        }

        public override bool IsTerminal => true;
    }
    
    
    public record DropPtr(ValueID Ptr) : InstructionKind
    {
        public override string ToString()
            => $"drop ptr {Ptr}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Ptr);
        }
    }
    public record DropVal(ValueID Val) : InstructionKind
    {
        public override string ToString()
            => $"drop val {Val}";
        public override void GetArguments(IList<ValueID> values)
        {
            values.Add(Val);
        }
    }

    public record Error : InstructionKind
    {
        public override string ToString()
            => $"error";
    }
}
