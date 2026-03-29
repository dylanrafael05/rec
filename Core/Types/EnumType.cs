using Re.C.Definitions;

namespace Re.C.Types;

public class EnumType : NamedType
{
    private EnumMember[]? members = null;

    public required Scope InnerScope { get; init; }
    public Option<EnumMember[]> Members => Option.Nonnull(members);

    public override bool IsEnum => true;
    
    public void SetMembers(EnumMember[] members)
    {
        if (this.members is not null)
            throw Panic("Attempt to set the body of an enum more than once.");

        this.members = members;
    }
}
