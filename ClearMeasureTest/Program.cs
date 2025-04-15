// See https://aka.ms/new-console-template for more information

using NumberAndNameGenerator;

try
{
    var output = NumberAndNameService.GetLines(100, 3, 5, new List<Name> { new("Greg", "Goldsmith") });
    Console.WriteLine("Starting to write one name.");
    Console.WriteLine();
    foreach (var line in output)
    {
        Console.WriteLine(line);
    }
    Console.WriteLine();
    Console.WriteLine("Complete. Total lines for one name: " + output.Count);
    Console.WriteLine();
    output = NumberAndNameService.GetLines(100, 4, 7, new List<Name> { new("Greg", "Goldsmith"), new ("Tara", "Kohler") });
    Console.WriteLine("Starting to write two names.");
    Console.WriteLine();
    foreach (var line in output)
    {
        Console.WriteLine(line);
    }
    Console.WriteLine();
    Console.WriteLine("Complete. Total lines for two names: " + output.Count);
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

