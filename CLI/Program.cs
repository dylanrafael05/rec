using Re.C;
using Re.C.CLI;
using Re.C.LLVM;
using Re.C.Vocabulary;

Console.WriteLine($"Running compiler!");

var ctx = RecContext.Create();
var llvm = LLVMContext.Create(ctx);

foreach (var arg in args)
{
    var source = new Source(arg, File.ReadAllText(arg));
    ctx.AddSource(source);

    Console.WriteLine($"Adding source {source.Name}");
}

try
{
    llvm.CompileAll();
}
finally
{
    foreach (var diag in ctx.Diagnostics)
    {
        Console.WriteLine(diag.Format());
    }
}

Console.WriteLine(llvm.Module.PrintToString());