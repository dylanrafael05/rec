using Re.C.Definitions;
using Re.C.Syntax;
using Re.C.Types;

namespace Re.C.IR;

public abstract record InstructionKind
{
    public virtual void GetJumpBlocks(IList<InstructionBlock> blocks)
    {}
    public virtual void GetArguments(IList<ValueRef> values)
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
    public record StructLiteral(ValueRef[] Fields) : InstructionKind
    {
        public override string ToString()
            => $"struct [{string.Join(", ", Fields)}]";
        public override void GetArguments(IList<ValueRef> values)
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

    public record ArrayLiteral(ArrayConstruction Construction) : InstructionKind
    {
        public override string ToString()
            => Construction.ToString();
        public override void GetArguments(IList<ValueRef> values)
            => Construction.GetArguments(values);
    }
    public record ArraySize(ValueRef Array) : InstructionKind
    {
        public override string ToString()
            => $"{Array} .size";
        public override void GetArguments(IList<ValueRef> values)
            => values.Add(Array);
    }
    public record ArrayPtr(ValueRef Array) : InstructionKind
    {
        public override string ToString()
            => $"{Array} .ptr";
        public override void GetArguments(IList<ValueRef> values)
            => values.Add(Array);
    }
    public record IndexAddress(ValueRef Array, ValueRef Index) : InstructionKind
    {
        public override string ToString()
            => $"{Array}[{Index}]&";

        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Array);
            values.Add(Index);
        }
    }
    
    /// <summary>
    /// "leak" is a special instruction which signals that the value returned by this
    /// instruction can be moved from multiple times (that is, the value is 'leaked' from
    /// the perspective of the move checker). It is used to implement the 'break' expression
    /// syntax.
    /// </summary>
    public record Leak(ValueRef Value) : InstructionKind
    {
        public override string ToString()
            => $"leak {Value}";

        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Value);
        }
    }

    public record Argument(int Index) : InstructionKind
    {
        public override string ToString()
            => $"argument {Index}";
    }

    public record Binary(ValueRef LHS, ValueRef RHS, BinaryOperator Operator) : InstructionKind
    {
        public override string ToString()
            => $"{LHS} {BinaryOperator.GetRepr(Operator)} {RHS}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(LHS);
            values.Add(RHS);
        }
    }
    public record Unary(ValueRef Op, UnaryOperator Operator) : InstructionKind
    {
        public override string ToString()
            => $"{UnaryOperator.GetRepr(Operator)} {Op}";
            
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Op);
        }
    }
    public record Local(ValueRef Value) : InstructionKind
    {
        public override string ToString()
            => $"new local, init {Value}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Value);
        }
    }

    public record FieldPtr(ValueRef Ptr, int Index) : InstructionKind
    {
        public override string ToString()
            => $"fieldptr {Ptr} field {Index}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Ptr);
        }
    }
    public record FieldCopy(ValueRef Value, int Index) : InstructionKind
    {
        public override string ToString()
            => $"fieldcp {Value} field {Index}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Value);
        }
    }

    public record Load(ValueRef Ptr) : InstructionKind
    {
        public override string ToString()
            => $"load {Ptr}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Ptr);
        }
    }
    public record Store(ValueRef Ptr, ValueRef Value, bool Uninit) : InstructionKind
    {
        public override string ToString()
            => $"store {(Uninit ? "uninit " : "")}{Ptr} <- {Value}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Ptr);
            values.Add(Value);
        }
    }

    public record Call(ValueRef TargetPtr, ValueRef[] Arguments) : InstructionKind
    {
        public override string ToString()
            => $"call {TargetPtr} with {string.Join(", ", Arguments)}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(TargetPtr);
            foreach(var f in Arguments)
                values.Add(f);
        }
    }
    public record BuiltinCast(ValueRef Value) : InstructionKind
    {
        public override string ToString()
            => $"cast {Value}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Value);
        }
    }

    public record Phi(Dictionary<InstructionBlock, ValueRef> Incoming) : InstructionKind
    {
        public override string ToString()
            => $"phi {string.Join(", ", from kvp in Incoming select $"{kvp.Key.Name}: {kvp.Value}")}";
        
        public override void GetArguments(IList<ValueRef> values)
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
    public record Return(ValueRef Value) : InstructionKind
    {
        public override string ToString()
            => $"return {Value}";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Value);
        }

        public override bool IsTerminal => true;
    }
    public record Branch(ValueRef Cond, InstructionBlock WhenTrue, InstructionBlock WhenFalse) : InstructionKind
    {
        public override string ToString()
            => $"if {Cond} then {WhenTrue.Name} else {WhenFalse.Name}";
        
        public override void GetJumpBlocks(IList<InstructionBlock> blocks)
        {
            blocks.Add(WhenTrue);
            blocks.Add(WhenFalse);
        }
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Cond);
        }

        public override bool IsTerminal => true;
    }
    
    public record Drop(ValueRef Value, bool Named, DropMethod Method) : InstructionKind
    {
        public override string ToString()
            => $"drop{(Named ? " named" : "")} {Value} via {
                Method switch
                {
                    DropMethod.ThroughPointer => "ptr",
                    DropMethod.ThroughArray => "array",
                    DropMethod.Direct => "value",

                    _ => throw Unreachable
                }
            }";
        public override void GetArguments(IList<ValueRef> values)
        {
            values.Add(Value);
        }
    }

    public record Error : InstructionKind
    {
        public override string ToString()
            => $"error";
    }
}
