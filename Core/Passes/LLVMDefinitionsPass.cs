using Antlr4.Runtime.Misc;
using Re.C.Definitions;

namespace Re.C.Passes;

public class LLVMDefinitionsPass(RecContext ctx) : BasePass(ctx)
{
    public override bool EnterAsBlocks => true;
    
    public override Unit VisitFnDefine([NotNull] RecParser.FnDefineContext context)
    {
        // TODO: mangle names here?
        context.DefinedFunction?.LLVMFunction = Option.Some(
            CTX.Module.AddFunction(
                context.DefinedFunction.FullName,
                context.DefinedFunction.Type.Compile(CTX)));

        return default;
    }
}
