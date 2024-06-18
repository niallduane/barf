using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Barf.Cli;

public class BarfConfiguration
{
    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }
    public string? WorkingDirectory { get; set; }
}

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
}