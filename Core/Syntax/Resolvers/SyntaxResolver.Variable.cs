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

        if (defn is Variable var)
        {
            return new VariableExpression
            {
                Span = span,
                Type = var.Type,
                Variable = var
            };
        }
        else if (defn is Function fn)
        {
            return new FunctionExpression
            {
                Span = span,
                Type = fn.Type,
                Function = fn
            };
        }
        
        // TODO: report an error message here //
        
        return new ErrorExpression
        {
            Span = span,
            Type = CTX.BuiltinTypes.Error
        };
    }
}