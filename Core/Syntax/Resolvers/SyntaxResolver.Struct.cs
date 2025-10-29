using System.Text;
using Antlr4.Runtime.Misc;
using OneOf;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    public override BoundSyntax VisitStructExpression([NotNull] RecParser.StructExpressionContext context)
    {
        var span = context.CalculateSourceSpan();
        var type = CTX.Resolvers.Type.Visit(context.StructType);

        // Reject non-struct constructions //
        if(type is not StructType stype)
        {
            if(!type.ContainsError)
            {
                CTX.Diagnostics.AddError(
                    context.CalculateSourceSpan(),
                    Errors.InvalidStructExprTarget(type));
            }

            return BoundSyntax.ErrorExpression(context, CTX);
        }

        // Handle each field individually //
        var sfields = stype.Fields.UnwrapNull();
        var fieldCount = sfields.Length;
        var fields = new Expression[fieldCount];
        
        var missingFields = Enumerable.Range(0, fieldCount).ToHashSet();

        foreach(var fieldExpr in context._Parts)
        {
            var fieldname = fieldExpr.Field.TextAsIdentifier;
            var fieldOption = stype.FindField(fieldname);

            // Handle undefined fields //
            if(fieldOption.IsNone)
            {
                CTX.Diagnostics.AddError(
                    fieldExpr.Field.SourceSpan, 
                    Errors.UndefinedStructField(stype, fieldname));
                
                continue;
            }

            var field = fieldOption.Unwrap();
            var value = Visit(fieldExpr.Value).UnwrapAs<Expression>();
            
            fields[field.Index] = value;
            missingFields.Remove(field.Index);

            // Handle type mismatch //
            if(value.Type != field.Type)
            {
                CTX.Diagnostics.AddError(
                    fieldExpr.Field.SourceSpan, 
                    Errors.StructFieldTypeMismatch(stype, fieldname, field.Type, value.Type));
            }
        }

        // Handle missing fields //
        if(missingFields.Count != 0)
        {
            CTX.Diagnostics.AddError(
                span, Errors.StructMissingFields(stype, [
                    ..from f in sfields 
                    where missingFields.Contains(f.Index) 
                    select f.Name
                ]));
        }

        return new StructExpression
        {
            Span = span,
            Type = stype,
            Fields = fields
        };
    }
}