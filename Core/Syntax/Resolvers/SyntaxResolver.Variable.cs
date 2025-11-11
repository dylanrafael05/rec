using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitVariableReference([NotNull] RecParser.VariableReferenceContext context)
    {
        var span = context.CalculateSourceSpan();

        var defn = context.fullIdentifier() is var fident and not null 
            ? CTX.Scopes.Current.DeepSearchOrDiagnose(
                [..from p in fident._Parts select p.SourceSpan], 
                [..from p in fident._Parts select p.TextAsIdentifier])
            : CTX.Scopes.Current.SearchOrDiagnose(
                span, Identifier.Name(context.GetText()));

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