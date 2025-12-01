using Re.C.Definitions;

namespace Re.C.Types;

public class TemplateInstanceType : RecType
{
    private Field[]? fields;
    private TypeSubstitutions? substitutions;

    public TypeSubstitutions Substitutions 
        => substitutions ??= TypeSubstitutions.Of([..
            Template.TypeArguments.Zip(Arguments)
        ]);
    public required Seq<RecType> Arguments { get; init; }
    public required StructTemplate Template { get; init; }

    public override bool IsStructural => true;
    public override Option<Field[]> Fields
        => Option.Some(fields ??= [..
            from f in Template.Fields.Unwrap()
            select new Field(
                f.Name,
                f.Type.ApplySubstitutions(Substitutions),
                f.Index
            )
        ]);

    public override string Name => $"{Template.Identifier}!<{string.Join(
        ", ", from a in Arguments select a.Name
    )}>";
    public override string FullName => $"{Template.FullName}!<{string.Join(
        ", ", from a in Arguments select a.FullName
    )}>";

    public override bool Equals(RecType? other)
        => other is TemplateInstanceType temp
        && temp.Template == Template
        && temp.Arguments == Arguments;

    public override int GetHashCode()
        => HashCode.Combine(Template, Arguments);

    public override void PropogateVisitor<V>(V visitor)
    {
        if(fields is not null)
            visitor.VisitMany(Fields.Unwrap(), f => f.Type, "Fields");

        visitor.VisitMany(Arguments);
    }
}