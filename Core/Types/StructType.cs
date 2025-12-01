namespace Re.C.Types;

public class StructType : NamedType, IStructlikeDefinition
{
    private Field[]? fields = null;

    public override bool IsStructural => true;
    public override Option<Field[]> Fields => Option.Nonnull(fields);
    public override bool TriviallyCopyable => false;

    /// <summary>
    /// Find the field associated with the provided name.
    /// </summary>
    public override Option<Field> FindField(Identifier name)
    {
        var fields = this.fields.UnwrapNull();
        for(var i = 0; i < fields.Length; i++)
        {
            if(fields[i].Name == name)
                return Option.Some(fields[i]);
        }

        return Option.None;
    }

    public void SetBody(Field[] fields)
    {
        if (this.fields is not null)
            throw Panic("Attepmt to set the body of a struct more than once.");

        this.fields = fields;
    }

    public override void PropogateVisitor<V>(V visitor)
    {
        if(fields is not null)
            visitor.VisitMany(fields, f => f.Type);
    }
}