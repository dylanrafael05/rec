using Antlr4.Runtime.Misc;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.Vocabulary;

namespace Re.C.Passes;

public class FileDeclarationsPass(RecContext ctx) : BasePass(ctx)
{
    public override Unit VisitModStatement([NotNull] RecParser.ModStatementContext context)
    {
        // Get the scope referred to by this mod statement
        //
        // Note that the scope may not exist yet, and as such it must be
        // defined on-the-fly while searching for it
        //
        // Also of note is that the search always begins at the current scope
        // level, and never accounts for imported scopes
        var scope = CTX.Scopes.Current;

        foreach (var partToken in context.ModuleIdent._Parts)
        {
            var part = Identifier.Name(partToken.Text);

            if (scope.Definitions.TryGetValue(part, out var subscopeDef))
            {
                if (subscopeDef is Scope subscope)
                {
                    scope = subscope;
                }
                else
                {
                    CTX.Diagnostics.AddError(
                        partToken.SourceSpan,
                        Errors.Redefinition(part, scope));

                    scope = CTX.Scopes.Current;
                    break;
                }
            }
            else
            {
                scope = scope.Define(new Scope { Identifier = part, CTX = CTX })!;
            }
        }

        context.Scope = scope;

        return base.VisitModStatement(context);
    }
}
