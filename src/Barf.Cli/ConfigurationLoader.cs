using System.Text.Json;

using Barf.Cli.Models;

namespace Barf.Cli;

public class ConfigurationLoader
{
    public static BarfConfiguration? LoadBarfFile()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, ".barf");

        Console.WriteLine($"getting configuration: {filePath}");

        if (!File.Exists(filePath))
        {
            throw new Exception(".barf config does not exist");
        }

        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine($"configuration contents: {fileContent}");

        var config = JsonSerializer.Deserialize<BarfConfiguration>(fileContent);
        if (config != null)
        {
            config.WorkingDirectory = currentDirectory;
            return config;
        }
        return null;
    }

    public static void Update(BarfConfiguration configuration)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, ".barf");

        Console.WriteLine($"getting configuration: {filePath}");
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        File.WriteAllText(filePath, JsonSerializer.Serialize(configuration));
    }
}