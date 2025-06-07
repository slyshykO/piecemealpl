using System.CommandLine;
using System.CommandLine.Invocation;

var f = new Option<string>("-f", "filename");
var i = new Option<int?>("-i", "option");
var l = new Option<int?>("-l", "option");
var r = new Option<int?>("-r", "option");
var rootCommand = new RootCommand("Test")
{
    f,
    i,
    l,
    r,
};

rootCommand.SetHandler((f, i, l, r) =>
{
    if (!string.IsNullOrEmpty(f)) 
    {
        Console.WriteLine($"filename : {f}");
    }
    if (i.HasValue)
    {
        Console.WriteLine($"option : {i.Value}");
    }
    if (l.HasValue)
    {
        Console.WriteLine($"option : {l.Value}");
    }
    if (r.HasValue)
    {
        Console.WriteLine($"option : {r.Value}");
    }

}, f, i, l, r);

await rootCommand.InvokeAsync(args);