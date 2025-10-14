using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitVariableReference([NotNull] RecParser.VariableReferenceContext context)
    {
        var span = context.CalculateSourceSpan();

        var ident = context.Identifier().TextAsIdentifier;
        var defn = CTX.CurrentScope.SearchOrDiagnose(
            CTX, span, ident);

        if (defn is null)
        {
            return new ErrorExpression
            {
                Span = span,
                Type = CTX.BuiltinTypes.Error
            };
        }

        if (defn is not Variable var)
        {
            // TODO: report an error message here //
            
            return new ErrorExpression
            {
                Span = span,
                Type = CTX.BuiltinTypes.Error
            };
        }

        return new VariableExpression
        {
            Span = span,
            Type = var.Type,
            Variable = var
        };
    }
}