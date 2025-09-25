using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Re.C.Syntax.Binders;

public class TypeBinder(ITokenSource tokens) : RecBaseVisitor<Type>
{
    public override Type VisitTypenameSingle(RecParser.TypenameSingleContext context)
    {
        var interval = context.SourceInterval;
        var ident = context.Identifier();

    }
}