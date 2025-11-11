namespace Re.C.Types;

public class StructType : NamedType
{
    public record struct Field(Identifier Name, RecType Type, int Index);

    public Field[]? Fields { get; private set; }
    public override bool TriviallyCopyable => false;

    /// <summary>
    /// Find the field associated with the provided name.
    /// </summary>
    public Option<Field> FindField(Identifier name)
    {
        var fields = Fields.UnwrapNull();
        for(var i = 0; i < fields.Length; i++)
        {
            if(fields[i].Name == name)
                return Option.Some(fields[i]);
        }

        return Option.None;
    }

    public void SetBody(Field[] fields)
    {
        if (Fields is not null)
            throw Panic("Attepmt to set the body of a struct more than once.");

        Fields = fields;
    }

    public override void PropogateVisitor<V>(V visitor)
    {
        if(Fields is not null)
            visitor.VisitMany(Fields, f => f.Type);
    }
}