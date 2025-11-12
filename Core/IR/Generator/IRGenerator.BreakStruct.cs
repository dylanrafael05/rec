using Re.C.Syntax;

namespace Re.C.IR;

public partial class IRGenerator
{
    public void GenerateBreakStruct(BreakStructStatement context)
    {
        var value = Generate(context.Target);
        var leaked = Builder.BuildInst(context.Target, new InstructionKind.Leak(value));

        foreach(var part in context.Parts)
        {
            var fieldValue = Builder.BuildInst(
                part.Var.Type, 
                part.Var.DefinitionLocation, 
                new InstructionKind.FieldCopy(leaked, part.FieldIndex));
            
            LinkVariable(part.Var, fieldValue);
        }
    }
}