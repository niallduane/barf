using System.Text.Json.Serialization;

namespace Tada.Cli.Models;

public class TadaConfiguration
{
    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("database")]
    public DatabaseConfiguration? Database { get; set; }

    [JsonIgnore]
    public string? WorkingDirectory { get; set; }
}