using LLVMSharp.Interop;
using Re.C.Definitions;
using Re.C.Types.Descriptors;
using Re.C.Vocabulary;

namespace Re.C.Types;

public class StructType : NamedType
{
    public record struct Field(string Name, Type Type);

    public required Field[] Fields { get; init; }

    protected override LLVMTypeRef BuildLLVMType(ProgramContext ctx)
    {
        var type = ctx.Context.CreateNamedStruct(FullName); /* TODO: mangling */
        type.StructSetBody([.. from f in Fields select f.Type.GetLLVMType(ctx)], false);

        return type;
    }

    public override LLVMValueRef BuildDestructor(ProgramContext ctx)
    {
        throw new InvalidOperationException("TODO");
    }

    public override FieldDescriptor[] GetFields(ProgramContext ctx)
    {
        var llvm = GetLLVMType(ctx);

        return [
            ..from f in Fields.Indexed select new FieldDescriptor
            {
                Name = f.value.Name,
                Offset = ctx.TargetData.OffsetOfElement(llvm, (uint) f.index),

                FieldType = default /* TODO */,
                ParentType = default /* TODO */
            }
        ];
    }
}