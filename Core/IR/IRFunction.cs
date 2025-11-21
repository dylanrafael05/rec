using System.Text;
using Re.C.Definitions;

namespace Re.C.IR;

public class IRFunction(Function function)
{
    public Function Function { get; } = function;

    private readonly List<InstructionBlock> blocks = [];
    private readonly Bimapping<Variable, ValueID> variables = [];
    private InstructionBlock? finalBlock;
    private readonly Dictionary<ValueID, Instruction> valueToInstruction = [];

    public InstructionBlock EntryBlock => blocks[0];
    public InstructionBlock FinalBlock => finalBlock.UnwrapNull();
    public IReadOnlyList<InstructionBlock> Blocks => blocks;
    public IReadOnlyBimapping<Variable, ValueID> VariableMappings => variables;
    
    private long maxValueID = 0;

    public Instruction InstructionByValue(ValueID value)
        => valueToInstruction[value];
    public void MapValueToInstruction(ValueID value, Instruction inst)
        => valueToInstruction.Add(value, inst);

    public ValueID NextValueID()
        => new(this, maxValueID++);

    public InstructionBlock NewBlock(Scope lexicalScope, string? name = null)
    {
        var result = new InstructionBlock(this, name ?? $"{Function.Identifier}_{Blocks.Count}", lexicalScope);
        blocks.Add(result);

        return result;
    }

    public void CleanUnreachableBlocks()
    {
        blocks.RemoveAll(b => !b.AllAntecedents.Contains(EntryBlock));
    }

    public void SetFinalBlock(InstructionBlock block)
    {
        // Debug assertion; make sure nothing fishy is going on!
        Assert(blocks.Contains(block), "The final block of a function must be from that function");
        finalBlock = block;
    }

    public void BindVariable(Variable var, ValueID valueID)
    {
        variables.Add(var, valueID);
    }

    public void RebindVariable(Variable var, ValueID valueID)
    {
        variables.Remove(var);
        variables.Add(var, valueID);
    }

    public string ToIRString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"; Definition of {Function.FullName}");

        foreach(var block in Blocks)
            sb.AppendLine(block.ToIRString());

        return sb.ToString();
    }
}
