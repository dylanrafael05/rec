using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitLetStatement([NotNull] RecParser.LetStatementContext context)
    {
        // Visit constituent parts //
        var span = context.CalculateSourceSpan();
        var expr = Visit(context.Value).UnwrapAs<Expression>();
        var type = context.VarType switch
        {
            null        => expr.Type,
            var nonnull => CTX.Resolvers.Type.Visit(nonnull)
        };

        expr = Coerce(expr, type);

        // Error on type mismatch //
        if (type != expr.Type)
        {
            CTX.Diagnostics.AddError(
                expr.Span,
                Errors.TypeMismatch(type, expr.Type));
        }

        // Attempt to define associated variable //
        var variable = CTX.Scopes.Current.DefineOrDiagnose(
            span,
            new Variable
            {
                Identifier = context.Target.TextAsIdentifier,
                Type = type.UnwrapNull(),
                DefinitionLocation = span
            }
        );

        // Return appropriate statement wrapper //
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