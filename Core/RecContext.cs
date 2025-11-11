using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Re.C.Antlr;
using Re.C.Definitions;
using Re.C.IR;
using Re.C.Passes;
using Re.C.Syntax.Resolvers;
using Re.C.Types;

namespace Re.C;

/// <summary>
/// The context of a Rec compilation. Includes all LLVM references,
/// all scopes and definitions, and information about builtins.
/// </summary>
public class RecContext
{
    #region // Private Members //
    private readonly List<Source> sources = [];
    private readonly Dictionary<Source, IParseTree> parseTrees = [];
    #endregion

    #region // Public Members //
    /// <summary>
    /// A list containing all sources added to this context.
    /// </summary>
    public IReadOnlyList<Source> Sources => sources;
    /// <summary>
    /// A mapping from source to parse tree.
    /// </summary>
    public IReadOnlyDictionary<Source, IParseTree> ParseTrees => parseTrees;

    /// <summary>
    /// A reference to all the builtin types.
    /// </summary>
    public BuiltinTypes BuiltinTypes { get; }

    /// <summary>
    /// The global scope of this compilation.
    /// </summary>
    public Scope GlobalScope { get; }

    /// <summary>
    /// The current source being compiled.
    /// </summary>
    public Source? CurrentSource { get; set; }
    /// <summary>
    /// A reference to the list of all imported scopes for the
    /// currently active source.
    /// </summary>
    public IReadOnlyCollection<Scope> CurrentImports => ImportsBySource.GetValueOrDefault(CurrentSource!) ?? [];

    /// <summary>
    /// A stack storing all scopes as they are superceded.
    /// </summary>
    public Scoped<Scope> Scopes { get; }
    /// <summary>
    /// A stack storing all functions as they are superceded.
    /// </summary>
    public Scoped<Function?> Functions { get; } = new(null);
    /// <summary>
    /// The object which tracks the associations between types and methods.
    /// </summary>
    public TypeAssociations TypeAssociations { get; }

    /// <summary>
    /// The diagnostic bag used for compilation. All diagnostics
    /// should be placed here.
    /// </summary>
    public DiagnosticBag Diagnostics { get; } = [];
    /// <summary>
    /// A mapping of sources to the scopes that they import.
    /// </summary>
    public MultiDictionary<Source, Scope> ImportsBySource { get; } = [];

    /// <summary>
    /// A reference to all passes for this context.
    /// </summary>
    public PassList DefaultPasses { get; }
    /// <summary>
    /// A reference to all the resolvers for this context.
    /// </summary>
    public RecResolvers Resolvers { get; }

    /// <summary>
    /// An instance of the ir generator.
    /// </summary>
    public IRGenerator IRGenerator { get; }
    /// <summary>
    /// An instance of the ir builder; a helper class to interface with
    /// instruction blocks.
    /// </summary>
    public IRBuilder IRBuilder { get; }
    #endregion

    #region // Functionality //
    private RecContext()
    {
        var scope = new Scope
        {
            CTX = this,
            Identifier = Identifier.None,
            Parent = null,
            DefinitionLocation = SourceSpan.Builtin
        };

        RecType MakePrimitive(string name, PrimitiveType.Class cls)
            => scope.Define(new PrimitiveType(cls) { 
                Identifier = Identifier.Name(name), 
                DefinitionLocation = SourceSpan.Builtin }).UnwrapNull();

        var types = new BuiltinTypes
        {
            Error = new ErrorType(),
            None = scope.Define(new NoneType { 
                Identifier = Identifier.Name("none"), 
                DefinitionLocation = SourceSpan.Builtin }).UnwrapNull(),

            Bool  = MakePrimitive("bool",  PrimitiveType.Class.Bool),
            I8    = MakePrimitive("i8",    PrimitiveType.Class.SignedInt),
            I16   = MakePrimitive("i16",   PrimitiveType.Class.SignedInt),
            I32   = MakePrimitive("i32",   PrimitiveType.Class.SignedInt),
            I64   = MakePrimitive("i64",   PrimitiveType.Class.SignedInt),
            ISize = MakePrimitive("isize", PrimitiveType.Class.SignedInt),
            U8    = MakePrimitive("u8",    PrimitiveType.Class.UnsignedInt),
            U16   = MakePrimitive("u16",   PrimitiveType.Class.UnsignedInt),
            U32   = MakePrimitive("u32",   PrimitiveType.Class.UnsignedInt),
            U64   = MakePrimitive("u64",   PrimitiveType.Class.UnsignedInt),
            USize = MakePrimitive("usize", PrimitiveType.Class.UnsignedInt),
            F32   = MakePrimitive("f32",   PrimitiveType.Class.Float),
            F64   = MakePrimitive("f64",   PrimitiveType.Class.Float),
        };

        DefaultPasses = new([
            new FileDeclarationsPass(this),
            new FileUsagesPass(this),
            new TypeDeclarationsPass(this),
            new FunctionDeclarationsPass(this),
            new TypeDefinitionsPass(this),
            new FunctionDefinitionsPass(this),

            new IRGenerationPass(this),
            new ReturnsAnalysis(this),
            new DropAnalysis(this),
        ]);

        Resolvers = new()
        {
            Type = new(this),
            Syntax = new(this)
        };

        IRGenerator = new(this);
        IRBuilder = new(this);

        GlobalScope = scope;
        Scopes = new(scope);
        BuiltinTypes = types;
        TypeAssociations = new(this);
    }

    /// <summary>
    /// Create a new RecContext. Properly assigns all required fields.
    /// This function should only be called once per compiler instance
    /// (not once per source compiled).
    /// </summary>
    public static RecContext Create()
        => new();
        
    /// <summary>
    /// Add a new source to this compilation.
    /// </summary>
    public void AddSource(Source source)
    {
        sources.Add(source);
    }

    /// <summary>
    /// Run the lexer and parser for the provided source.
    /// </summary>
    public void LexAndParse(Source source)
    {
        var charStream = CharStreams.fromString(source.Content);

        var lexer = new RecLexer(charStream) { Source = source };
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new DiagnosticLexerListener(this));

        var parser = new RecParser(new CommonTokenStream(lexer));
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new DiagnosticParserListener(this));

        var tree = parser.program();
        parseTrees.Add(source, tree);
    }

    /// <summary>
    /// Run the provided pass on all sources.
    /// </summary>
    public void ExecutePass(IRecVisitor<Unit> visitor)
    {
        foreach(var source in Sources)
        {
            CurrentSource = source;

            var tree = ParseTrees[source];
            visitor.Visit(tree);
            
            CurrentSource = null;
        }
    }

    /// <summary>
    /// Run all provided passes on all sources.
    /// </summary>
    public void ExecutePasses(PassList passes)
    {
        foreach(var pass in passes.All)
            ExecutePass(pass);
    }
    
    /// <summary>
    /// Perform all lexing, parsing, and analysis on all sources.
    /// </summary>
    public void AnalyzeAll()
    {
        foreach (var source in Sources)
            LexAndParse(source);

        ExecutePasses(DefaultPasses);
    }
    #endregion
}