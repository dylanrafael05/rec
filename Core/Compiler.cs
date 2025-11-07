using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using LLVMSharp;
using LLVMSharp.Interop;
using Re.C.Antlr;
using Re.C.IR;
using Re.C.Passes;

namespace Re.C;

public class Compiler
{
    private Compiler(RecContext ctx)
    {
        CTX = ctx;
    }

    private readonly List<Source> sources = [];

    public void AddSource(Source source)
    {
        sources.Add(source);
    }

    public RecContext CTX { get; }
    public IReadOnlyList<Source> Sources => sources;
    public Dictionary<Source, IParseTree> ParseTrees { get; } = [];

    public void CompileAll()
    {
        foreach (var source in Sources)
            LexAndParse(source);

        RunASTPass(CTX.Passes.FileDeclarations);
        RunASTPass(CTX.Passes.FileUsages);
        RunASTPass(CTX.Passes.TypeDeclarations);
        RunASTPass(CTX.Passes.FunctionDeclarations);
        RunASTPass(CTX.Passes.TypeDefinitions);
        RunASTPass(CTX.Passes.FunctionDefinitions);
        
        RunASTPass(CTX.Passes.IRGeneration);

        foreach(var pass in CTX.Passes.IRPasses)
            RunASTPass(pass);

        RunASTPass(CTX.Passes.LLVMDefinitions, refuseOnErrors: true);
        RunASTPass(CTX.Passes.LLVMGeneration, refuseOnErrors: true);

        CTX.Module.Verify(LLVMVerifierFailureAction.LLVMAbortProcessAction);
    }
    
    public void RunASTPass(IRecVisitor<Unit> visitor, bool refuseOnErrors = false)
    {
        foreach(var source in Sources)
        {
            CTX.CurrentSource = source;

            if (refuseOnErrors && CTX.Diagnostics.HasErrors(source))
                continue;

            var tree = ParseTrees[source];
            visitor.Visit(tree);
            
            CTX.CurrentSource = null;
        }
    }

    public void LexAndParse(Source source)
    {
        var charStream = CharStreams.fromString(source.Content);

        var lexer = new RecLexer(charStream) { Source = source };
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new DiagnosticLexerListener(CTX));

        var parser = new RecParser(new CommonTokenStream(lexer));
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new DiagnosticParserListener(CTX));

        var tree = parser.program();
        ParseTrees.Add(source, tree);
    }
    
    public static Compiler Create(string moduleName = "example_code")
    {
        var llvm = LLVMContextRef.Create();
        var context = RecContext.Create(llvm, moduleName);

        return new(context);
    }
}
