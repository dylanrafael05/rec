using System.Text;
using Re.C.Visitor;

namespace Re.C.IR;

public enum DropMethod
{
    ThroughPointer,
    Direct
}

public class InstructionBlock(IRFunction function, string name) : IVisitable
{
    public IRFunction Function { get; } = function;
    public string Name { get; } = name;

    public bool Returns { get; set; }

    public Dictionary<ValueID, DropMethod> DropAtEnd { get; } = [];
    public List<(Instruction, ValueID, DropMethod)> DropBeforeInstruction { get; } = [];
    public Dictionary<ValueID, SourceSpan> MovedValues { get; } = [];
    public HashSet<ValueID> LeakedValues { get; } = [];

    public bool IsFinalBlock => Function.FinalBlock == this;
    public bool IsEntryBlock => Function.EntryBlock == this;

    private readonly List<InstructionBlock> antecedents = [];
    private readonly List<InstructionBlock> consequents = [];
    private readonly List<Instruction> instructions = [];
    
    public int InstructionCount => instructions.Count;
    public IReadOnlyList<Instruction> Instructions => instructions;
    public IReadOnlyList<InstructionBlock> Antecedents => antecedents;
    public IReadOnlyList<InstructionBlock> Consequents => consequents;

    /// <summary>
    /// Insert the given instruction at the provided index.
    /// </summary>
    public ValueID InsertInstruction(int index, Instruction instruction)
    {
        var id = Function.NextValueID();
        instruction.ValueID = Option.Some(id);

        instructions.Insert(index, instruction);
        Function.MapValueToInstruction(id, instruction);

        var connectingBlocks = new List<InstructionBlock>();
        instruction.Kind.GetJumpBlocks(connectingBlocks);

        foreach(var blk in connectingBlocks)
        {
            consequents.Add(blk);
            blk.antecedents.Add(this);
        }

        return id;
    }

    /// <summary>
    /// Remove the instruction at the provided index
    /// </summary>
    public void RemoveInstruction(int index)
    {
        var instruction = instructions[index];

        var connectingBlocks = new List<InstructionBlock>();
        instruction.Kind.GetJumpBlocks(connectingBlocks);

        foreach(var blk in connectingBlocks)
        {
            consequents.Remove(blk);
            blk.antecedents.Remove(this);
        }

        instructions.RemoveAt(index);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(Name);

        if(IsFinalBlock)
            sb.Append(" <final>");
        
        if(IsEntryBlock)
            sb.Append(" <entry>");

        sb.AppendLine(":");

        foreach(var inst in instructions)
            sb.Append('\t').AppendLine($"{inst}");

        return sb.AppendLine().ToString();
    }

    public void PropogateVisitor<V>(V visitor) 
        where V : IVisitor, allows ref struct
    {
        visitor.VisitMany(Consequents);
    }
}
