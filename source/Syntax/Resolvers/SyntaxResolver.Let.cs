using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitLetStatement([NotNull] RecParser.LetStatementContext context)
    {
        var span = context.CalculateSourceSpan();
        var expr = (Visit(context.Value) as Expression).UnwrapNull();
        var type = CTX.Resolvers.Type.Visit(context.VarType) ?? expr.Type;

        if (type != expr.Type)
        {
            CTX.Diagnostics.AddError(
                expr.Span,
                Errors.TypeMismatch(type, expr.Type));
        }

        var variable = CTX.CurrentScope.DefineOrDiagnose(
            CTX, span,
            new Variable
            {
                Identifier = context.Target.TextAsIdentifier,
                Type = type.UnwrapNull()
            }
        );

        if (variable is null)
        {
            return new ErrorStatement
            {
                Span = span
            };
        }

        return new LetStatement
        {
            Span = span,
            Variable = variable,
            TargetValue = expr
        };
    }
}