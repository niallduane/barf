using System.Text.Json.Serialization;

namespace Barf.Cli.Models;

public class BarfConfiguration
{
    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("database")]
    public DatabaseConfiguration? Database { get; set; }

    [JsonIgnore]
    public string? WorkingDirectory { get; set; }
}