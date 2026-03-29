using Re.C.Definitions;

namespace Re.C.Types;

public interface IStructlikeDefinition : IDefinition
{
    public Option<Field[]> Fields { get; }
    public void SetBody(Field[] fields);
}