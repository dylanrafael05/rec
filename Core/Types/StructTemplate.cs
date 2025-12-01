using Re.C.Definitions;

namespace Re.C.Types;

public class StructTemplate : DefinitionBase, IStructlikeDefinition
{
    private Field[]? fields = null;

    public override string DefinitionKind => "struct template";
    
    public Option<Field[]> Fields => Option.Nonnull(fields);
    
    public required TemplateType[] TypeArguments { get; init; }
    public required Scope InternalScope { get; init; }

    public void SetBody(Field[] fields)
    {
        this.fields = fields;
    }
}