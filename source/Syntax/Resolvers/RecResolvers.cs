namespace Re.C.Syntax.Resolvers;

/// <summary>
/// A helper struct holding all the resolvers in
/// the re:c compiler.
/// 
/// Note that a 'resolver' converts parse tree
/// nodes into an alternate form, such as a Types.Type
/// or BoundSyntax, while a 'pass' simply visits the nodes
/// of the parse tree, modifying the global state of the program.
/// </summary>
public readonly struct RecResolvers
{
    public required TypeResolver Type { get; init; }
    public required SyntaxResolver Syntax { get; init; }
}
