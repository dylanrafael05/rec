using System.Text;
using Re.C.Definitions;

namespace Re.C.IR;

public class InstructionBlock(Function function, string name)
{
    public Function Function { get; } = function;
    public string Name { get; } = name;

    public ValueID InsertInstruction(int index, Instruction instruction)
    {
        var id = Function.IRFunction.Unwrap().NextValueID();
        instruction.ValueID = Option.Some(id);

        instructions.Insert(index, instruction);
        valueToInstruction.Add(id, instruction);

        return id;
    }

    public Instruction GetInstructionByValue(ValueID id)
        => valueToInstruction.GetValueOrDefault(id).UnwrapNull();

    public IReadOnlyList<Instruction> Instructions => instructions;

    private readonly List<Instruction> instructions = [];
    private readonly Dictionary<ValueID, Instruction> valueToInstruction = [];

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Name}:");

        foreach(var inst in instructions)
            sb.Append('\t').AppendLine($"{inst}");

        return sb.AppendLine().ToString();
    }
}
