using System.Text;
using Re.C.Definitions;
using Re.C.Visitor;

namespace Re.C.IR;

[DiscriminatedUnion]
public partial record struct DroppableValue
{
    public static class Cases
    {
        public record struct ViaPointer(ValueID Ptr);
        public record struct ViaDirect(ValueID Value);
    }
}

public class InstructionBlock(IRFunction function, string name) : IVisitable
{
    public IRFunction Function { get; } = function;
    public string Name { get; } = name;

    public Option<bool> Returns { get; set; }

    public bool VisitedByDropComputer { get; set; } = false;
    public List<DroppableValue> DropAtEnd { get; } = [];
    public List<(Instruction, DroppableValue)> DropBeforeInstruction { get; } = [];
    public Dictionary<ValueID, SourceSpan> MovedNamedValues { get; } = [];

    public bool IsFinalBlock => Function.FinalBlock == this;
    public bool IsEntryBlock => Function.EntryBlock == this;

    private readonly List<InstructionBlock> antecedents = [];
    private readonly List<InstructionBlock> consequents = [];
    private readonly List<Instruction> instructions = [];
    private readonly Dictionary<ValueID, Instruction> valueToInstruction = [];
    
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
        valueToInstruction.Add(id, instruction);

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

    public Instruction GetInstructionByValue(ValueID id)
        => valueToInstruction.GetValueOrDefault(id).UnwrapNull();

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
