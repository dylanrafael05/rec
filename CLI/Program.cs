using Re.C;
using Re.C.CLI;
using Re.C.Vocabulary;

Console.WriteLine($"Running compiler!");

var compiler = Compiler.Create();
foreach (var arg in args)
{
    var source = new Source(arg, File.ReadAllText(arg));
    compiler.AddSource(source);

    Console.WriteLine($"Adding source {source.Name}");
}

compiler.CompileAll();

foreach (var diag in compiler.CTX.Diagnostics)
{
    Console.WriteLine(diag.Format());
}