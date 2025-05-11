using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string path = "example.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Console.WriteLine("=== ReadAllText ===");
        Console.WriteLine(File.ReadAllText(path));

        Console.WriteLine("\n=== ReadLines ===");
        foreach (var line in File.ReadLines(path))
            Console.WriteLine(line);

        Console.WriteLine("\n=== StreamReader ===");
        using (var reader = new StreamReader(path, Encoding.UTF8))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
                Console.WriteLine(line);
        }

        Console.WriteLine("\n=== Async Read ===");
        string asyncContent = await File.ReadAllTextAsync(path);
        Console.WriteLine(asyncContent);
    }
}
