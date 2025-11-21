using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitBreakStructStatement([NotNull] RecParser.BreakStructStatementContext context)
    {
        var arg = Visit(context.Target).UnwrapAs<Expression>();

        if(arg.Type is not StructType argtype)
        {
            CTX.Diagnostics.AddError(
                arg.Span, 
                Errors.InvalidBreak(arg.Type));
            
            return BoundSyntax.ErrorExpression(context, CTX);
        }

        using var visitedFields = Temporary.HashSet<Identifier>();
        var parts = (List<BreakStructStatement.Part>)[];
        var anyErrors = false;
        
        foreach(var part in context._Parts)
        {
            var fieldID = part.Field.TextAsIdentifier;
            var fieldOption = argtype.FindField(fieldID);
            
            if(fieldOption.IsNone)
            {
                CTX.Diagnostics.AddError(
                    part.Field.SourceSpan, 
                    Errors.UndefinedField(argtype, fieldID));
                    
                anyErrors = true;
                continue;
            }

            if(visitedFields.Value.Contains(fieldID))
            {
                CTX.Diagnostics.AddError(
                    part.Field.SourceSpan,
                    Errors.BreakDuplicateStructField(fieldID));

                anyErrors = true;
                continue;
            }

            var field = fieldOption.Unwrap();
            visitedFields.Value.Add(fieldID);

            var variable = CTX.Scopes.Current.DefineOrDiagnose(
                part.CalculateSourceSpan(),
                new Variable
                {
                    Identifier = part.Name.TextAsIdentifier,
                    DefinitionLocation = part.CalculateSourceSpan(),
                    Type = field.Type
                }
            );

            if(variable is null)
            {
                anyErrors = true;
                continue;
            }

            parts.Add(new(variable, field.Index));
        }

        if(anyErrors)
            return BoundSyntax.ErrorExpression(context, CTX);

        return new BreakStructStatement
        {
            Span = context.CalculateSourceSpan(),
            Target = arg,
            Parts = [..parts]
        };
    }
}