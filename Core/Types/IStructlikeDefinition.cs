using Re.C.Definitions;

namespace Re.C.Types;

public interface IStructlikeDefinition : IDefinition
{
    public Option<Field[]> Fields { get; }
    public void SetBody(Field[] fields);
}

// public class GenericInstanceType : RecType
// {
//     public required StructType Template { get; init; }
//     // TODO; continue from here
// }