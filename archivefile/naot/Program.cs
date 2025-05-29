using System.IO.Compression;

using FileStream zipToOpen = new FileStream("experiment.zip", FileMode.OpenOrCreate);
using ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update);
var entry = archive.CreateEntry("hello.txt");
using var stream = await entry.OpenAsync();
using var writer = new StreamWriter(stream);
await writer.WriteLineAsync("Hello World!");

Console.WriteLine("Hello, World!");
