using System.Text;
using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Types;

namespace Re.C.Syntax.Resolvers;

public partial class SyntaxResolver
{
    /// <summary>
    /// Create a numerical literal
    /// </summary>
    private BoundSyntax MakeNumber(SourceSpan span, string text, string defaultSpecial)
    {
        var value = text.AsSpan();
        var specialStart = value.IndexOfAny(['i', 'u', 'f']);
        var special = defaultSpecial.AsSpan();

        if(specialStart is not -1)
        {
            value = value[..specialStart];
            special = text.AsSpan(specialStart..);
        }

        var type = special switch
        {
            "u8" => CTX.BuiltinTypes.U8,
            "u16" => CTX.BuiltinTypes.U16,
            "u32" => CTX.BuiltinTypes.U32,
            "u64" => CTX.BuiltinTypes.U64,
            "usize" => CTX.BuiltinTypes.USize,
            "i8" => CTX.BuiltinTypes.I8,
            "i16" => CTX.BuiltinTypes.I16,
            "i32" => CTX.BuiltinTypes.I32,
            "i64" => CTX.BuiltinTypes.I64,
            "isize" => CTX.BuiltinTypes.ISize,
            "f32" => CTX.BuiltinTypes.F32,
            "f64" => CTX.BuiltinTypes.F64,

            _ => throw Unimplemented
        };

        return special[0] switch
        {
            'u' or 'i' => new IntLiteral
            {
                Span = span,
                Type = type,
                Value = UInt128.Parse(value)
            },

            'f' => new FloatLiteral
            {
                Span = span,
                Type = type,
                Value = double.Parse(value)
            },

            _ => throw Unimplemented
        };
    }

    /// <summary>
    /// Convert int literals to syntax form.
    /// In reality, the type should be determined based on context and should
    /// probably default to i32.
    /// </summary>
    public override BoundSyntax VisitIntegerLiteral([NotNull] RecParser.IntegerLiteralContext context)
    {
        var text = context.Integer().Symbol.Text.UnwrapNull();

        return MakeNumber(context.CalculateSourceSpan(), text, "i32");
    }

    /// <summary>
    /// Convert a float literal to its syntax form.
    /// Assumes the target type is f64.
    /// </summary>
    public override BoundSyntax VisitFloatLiteral([NotNull] RecParser.FloatLiteralContext context)
    {
        var text = context.Float().Symbol.Text;

        return MakeNumber(context.CalculateSourceSpan(), text, "f32");
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
        var raw = context.String().GetText()[1..^1];

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
            else value.Append(raw[index]);

            index++;
        }

        return new StringLiteral
        {
            Span = span,
            Type = RecType.Pointer(CTX.BuiltinTypes.U8),
            Value = value.ToString()
        };
    }
}