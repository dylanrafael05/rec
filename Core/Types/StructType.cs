using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Types.Descriptors;
using Re.C.Visitor;
using Re.C.Vocabulary;

namespace Re.C.Types;

public class StructType : NamedType
{
    public record struct Field(Identifier Name, Type Type, int Index);

    public Field[]? Fields { get; private set; }

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

    protected override LLVMTypeRef ImplementCompile(RecContext ctx)
    {
        var type = ctx.LLVM.CreateNamedStruct(FullName); /* TODO: mangling */
        type.StructSetBody(
            [..from f in Fields.UnwrapNull() select f.Type.Compile(ctx)], 
            false);

        return type;
    }

    public override LLVMValueRef BuildDestructor(RecContext ctx)
    {
        throw Todo;
    }

    public override FieldDescriptor[] GetFields(RecContext ctx)
    {
        var llvm = Compile(ctx);

        throw Todo;

        return [
            ..from f in Fields.UnwrapNull().Indexed select new FieldDescriptor
            {
                Name = f.value.Name.ToString(),
                Offset = ctx.TargetData.OffsetOfElement(llvm, (uint) f.index),

                FieldType = default /* TODO */,
                ParentType = default /* TODO */
            }
        ];
    }

    public override void PropogateVisitor<V>(V visitor)
    {
        if(Fields is not null)
            visitor.VisitMany(Fields, f => f.Type);
    }
}