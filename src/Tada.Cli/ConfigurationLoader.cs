using System.Text.Json;

using Tada.Cli.Models;

namespace Tada.Cli;

public class ConfigurationLoader
{
    public static TadaConfiguration? LoadTadaFile()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, ".tada");

        Console.WriteLine($"getting configuration: {filePath}");

        if (!File.Exists(filePath))
        {
            throw new Exception(".tada config does not exist");
        }

        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine($"configuration contents: {fileContent}");

        var config = Json.Deserialize<TadaConfiguration>(fileContent);
        if (config != null)
        {
            config.WorkingDirectory = currentDirectory;
            return config;
        }
        return null;
    }

    public static void Update(TadaConfiguration configuration)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, ".tada");

        Console.WriteLine($"getting configuration: {filePath}");
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        File.WriteAllText(filePath, Json.Serialize(configuration));
    }
}