using Antlr4.Runtime.Misc;
using Re.C.Types;
using Re.C.Antlr;
using Re.C.Definitions;

namespace Re.C.Passes;

public class TypeDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitStructDefine([NotNull] RecParser.StructDefineContext context)
    {
        var span = context.CalculateSourceSpan();

        IStructlikeDefinition def;

        if(context.templateDef() is not null and var template)
        {
            var innerScope = new Scope
            {
                Identifier = Identifier.None,
                Parent = CTX.Scopes.Current,
                DefinitionLocation = template.CalculateSourceSpan(),
                CTX = CTX
            };

            var args = (List<TemplateType>)[];

            foreach(var (arg, index) in template._Args.Indexed)
            {
                var argspan = arg.CalculateSourceSpan();
                var argty = innerScope.DefineOrDiagnose(
                    argspan,
                    new TemplateType
                    {
                        Index = index,
                        Identifier = arg.Identifier().TextAsIdentifier,
                        DefinitionLocation = argspan
                    }
                );

                if(argty is not null) 
                    args.Add(argty);
            }

            def = new StructTemplate
            {
                Identifier = context.Identifier().TextAsIdentifier,
                DefinitionLocation = span,
                TypeArguments = [..args],
                InternalScope = innerScope
            };
        }
        else
        {
            def = new StructType
            {
                Identifier = context.Identifier().TextAsIdentifier,
                DefinitionLocation = span,
            };
        }

        CTX.Scopes.Current.DefineOrDiagnose(span, def);
        context.DefinedType = def;

        return default;
    }
}
