using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Types.Descriptors;
using Re.C.Vocabulary;

namespace Re.C.Types;

public class StructType : NamedType
{
    public record struct Field(string Name, Type Type);

    public Field[]? Fields { get; private set; }

    public void SetBody(Field[] fields)
    {
        if (Fields is not null)
            throw Panic("Attepmt to set the body of a struct more than once.");

        Fields = fields;
    }

    protected override LLVMTypeRef BuildLLVMType(RecContext ctx)
    {
        var type = ctx.Context.CreateNamedStruct(FullName); /* TODO: mangling */
        type.StructSetBody([.. from f in Fields select f.Type.GetLLVMType(ctx)], false);

        return type;
    }

    public override LLVMValueRef BuildDestructor(RecContext ctx)
    {
        throw Todo;
    }

    public override FieldDescriptor[] GetFields(RecContext ctx)
    {
        var llvm = GetLLVMType(ctx);

        throw Todo;

        return [
            ..from f in Fields.UnwrapNull().Indexed select new FieldDescriptor
            {
                Name = f.value.Name,
                Offset = ctx.TargetData.OffsetOfElement(llvm, (uint) f.index),

                FieldType = default /* TODO */,
                ParentType = default /* TODO */
            }
        ];
    }
}