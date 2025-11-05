using System.Text;
using Re.C.Definitions;

namespace Re.C.IR;

public class IRFunction(Function function)
{
    public Function Function { get; } = function;
    public List<InstructionBlock> Blocks { get; } = [];
    public Dictionary<Variable, ValueID> VariableIDs { get; } = [];
    
    private long maxValueID = 0;

    public ValueID NextValueID()
        => new(this, maxValueID++);

    public InstructionBlock NewBlock(string? name = null)
    {
        var result = new InstructionBlock(Function, name ?? $"{Function.Identifier}_{Blocks.Count}");
        Blocks.Add(result);

        return result;
    }

    public string ToIRString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"; Definition of {Function.FullName}");

        foreach(var block in Blocks)
            sb.AppendLine($"{block}");

        return sb.ToString();
    }
}
