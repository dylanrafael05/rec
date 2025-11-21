using System.Text;
using Re.C.Definitions;
using Re.C.Visitor;

namespace Re.C.IR;

public enum DropMethod
{
    ThroughPointer,
    ThroughArray,
    Direct
}

public class InstructionBlock(IRFunction function, string name, Scope lexicalScope) : IVisitable
{
    public IRFunction Function { get; } = function;
    public string Name { get; } = name;
    public Scope LexicalScope { get; } = lexicalScope;

    public bool DefinitelyReturns { get; set; }

    public Dictionary<ValueID, DropMethod> DropAtEnd { get; } = [];
    public List<(Instruction, ValueID, DropMethod)> DropBeforeInstruction { get; } = [];
    public Dictionary<ValueID, SourceSpan> MovedValues { get; } = [];
    public HashSet<ValueID> LeakedValues { get; } = [];

    public bool IsFinalBlock => Function.FinalBlock == this;
    public bool IsEntryBlock => Function.EntryBlock == this;

    private readonly List<InstructionBlock> antecedents = [];
    private readonly List<InstructionBlock> consequents = [];
    private readonly List<Instruction> instructions = [];
    private readonly MultiSet<InstructionBlock> allAntecedents = [];
    
    public int InstructionCount => instructions.Count;
    public IReadOnlyList<Instruction> Instructions => instructions;
    public IReadOnlyList<InstructionBlock> Antecedents => antecedents;
    public IReadOnlyList<InstructionBlock> Consequents => consequents;
    public IReadOnlyCollection<InstructionBlock> AllAntecedents => allAntecedents;
    public bool CanRecurse => allAntecedents.Contains(this);

    public bool IsComplete => instructions.Count > 0 && instructions[^1].Kind.IsTerminal;

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

            using var visited = Temporary.HashSet<InstructionBlock>();
            CalculateAllAntecedents(visited.Value, blk, blk, remove: false);
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

            using var visited = Temporary.HashSet<InstructionBlock>();
            CalculateAllAntecedents(visited.Value, blk, blk, remove: true);
        }

        instructions.RemoveAt(index);
    }

    /// <summary>
    /// Recursively update the 'all antecedents' variable for some block
    /// </summary>
    private static void CalculateAllAntecedents(
        HashSet<InstructionBlock> visited, 
        InstructionBlock start, 
        InstructionBlock block, 
        bool remove)
    {
        if(visited.Contains(block))
            return;

        visited.Add(block);
        foreach(var antecedent in block.Antecedents)
        {
            if(remove)
            {
                start.allAntecedents.Remove(antecedent);
            }
            else 
            {
                start.allAntecedents.Add(antecedent);
            }

            CalculateAllAntecedents(visited, start, antecedent, remove);
        }
    }

    public string ToIRString()
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
