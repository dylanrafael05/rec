using Re.C.Types;
using Antlr4.Runtime.Misc;

namespace Re.C.Syntax.Resolvers;

/// <summary>
/// A resolver type for types; this class
/// is responsible for resolving the syntax trees for
/// a typename into the type it represents.
/// 
/// Calls to this class' Visit method with non-typename
/// syntax trees are ill formed.
/// </summary>
public class TypeResolver(RecContext ctx) : RecBaseVisitor<Types.Type>
{
    public override Types.Type VisitTypenameSingle(RecParser.TypenameSingleContext single)
    {
        var def = IdentifierResolution.Resolve(ctx, single.Ident);
        return (def as NamedType) ?? ctx.BuiltinTypes.Error;
    }

    public override Types.Type VisitTypenamePointer([NotNull] RecParser.TypenamePointerContext context)
    {
        var inner = Visit(context.Base);

        if (inner is ErrorType)
            return inner;

        return new PointerType { Pointee = inner };
    }
}
