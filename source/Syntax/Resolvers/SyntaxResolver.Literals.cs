using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    /// <summary>
    /// Convert int literals to syntax form.
    /// 
    /// TODO: for now, the target type is always assumed to be u64.
    /// In reality, the type should be determined based on context and should
    /// probably default to i32.
    /// </summary>
    public override BoundSyntax VisitIntegerLiteral([NotNull] RecParser.IntegerLiteralContext context)
    {
        var text = context.Integer().Symbol.Text;

        return new IntLiteral
        {
            Span = context.CalculateSourceSpan(),
            Type = CTX.BuiltinTypes.U64,
            Value = UInt128.Parse(text)
        };
    }

    /// <summary>
    /// Convert a float literal to its syntax form.
    /// Assumes the target type is f64.
    /// </summary>
    public override BoundSyntax VisitFloatLiteral([NotNull] RecParser.FloatLiteralContext context)
    {
        var text = context.Float().Symbol.Text;

        return new FloatLiteral
        {
            Span = context.CalculateSourceSpan(),
            Type = CTX.BuiltinTypes.F64,
            Value = double.Parse(text)
        };
    }

    /// <summary>
    /// Convert a boolean literal to its syntax form.
    /// Note that an integer literal is used for convenience.
    /// </summary>
    public override BoundSyntax VisitBoolLiteral([NotNull] RecParser.BoolLiteralContext context)
    {
        var value = context.True() is not null;

        return new IntLiteral
        {
            Span = context.CalculateSourceSpan(),
            Type = CTX.BuiltinTypes.Bool,
            Value = (UInt128)(value ? 1 : 0)
        };
    }

    /// <summary>
    /// Convert a string literal to its syntax form.
    /// This process is responsible for the handling of escape sequences.
    /// 
    /// For the moment, the returned string is in pointer format.
    /// </summary>
    public override BoundSyntax VisitStringLiteral([NotNull] RecParser.StringLiteralContext context)
    {
        var span = context.CalculateSourceSpan();
        var raw = context.String().Symbol.Text[1..^1];

        var value = new StringBuilder();
        var index = 0;

        while (index < raw.Length)
        {
            if (raw[index] == '\\')
            {
                var chr = raw[++index] switch
                {
                    'n' => '\n',
                    'r' => '\r',
                    't' => '\t',
                    '\\' => '\\',
                    '"' => '"',
                    '0' => '\0',

                    _ => (char)0
                };

                if (chr == 0)
                {
                    var start = span.Start;
                    start.Column += index;

                    var end = start;
                    end.Column++;

                    CTX.Diagnostics.AddError(
                        new(span.Source, start, end),
                        Errors.UnknownEscapeSequence(raw[(index - 1)..index]));
                }

                value.Append(chr);
            }

            index++;
        }

        return new StringLiteral
        {
            Span = span,
            Type = new PointerType
            {
                Pointee = CTX.BuiltinTypes.U8
            },
            Value = value.ToString()
        };
    }
}