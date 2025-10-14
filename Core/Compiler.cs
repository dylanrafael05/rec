using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using LLVMSharp;
using LLVMSharp.Interop;
using Re.C.Antlr;
using Re.C.Passes;

namespace Re.C;

public class Compiler
{
    private Compiler(RecContext ctx)
    {
        CTX = ctx;
    }

    public RecContext CTX { get; }
    public List<Source> Sources { get; } = [];
    public Dictionary<Source, IParseTree> ParseTrees { get; } = [];

    // TODO: complete definition of compiler class;
    // add functionality to run all passes in successive order and output
    public void CompileAll()
    {
        foreach (var source in Sources)
            LexAndParse(source);

        var passes = new RecPasses
        {
            FileDeclarations = new FileDeclarationsPass(CTX),
            TypeDeclarations = new TypeDeclarationsPass(CTX),
            FunctionDeclarations = new FunctionDeclarationsPass(CTX),
            TypeDefinitions = new TypeDefinitionsPass(CTX),
            FunctionDefinitions = new FunctionDefinitionsPass(CTX)
        };

        RunASTPass(passes.FileDeclarations);
        RunASTPass(passes.TypeDeclarations);
        RunASTPass(passes.FunctionDeclarations);
        RunASTPass(passes.TypeDeclarations);
        RunASTPass(passes.FunctionDefinitions);
    }
    
    public void RunASTPass(IRecVisitor<Unit> visitor)
    {
        foreach(var source in Sources)
        {
            if (CTX.Diagnostics.HasErrors(source))
                continue;

            var tree = ParseTrees[source];
            visitor.Visit(tree);
        }
    }

    public void LexAndParse(Source source)
    {
        var charStream = CharStreams.fromString(source.Content);

        var lexer = new RecLexer(charStream) { Source = source };
        lexer.AddErrorListener(new DiagnosticLexerListener(CTX));

        var parser = new RecParser(new CommonTokenStream(lexer));
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
