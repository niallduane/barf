using System.Text.Json.Serialization;

using Tada.Cli.Types;

namespace Tada.Cli.Models;

public class DatabaseConfiguration
{
    [JsonPropertyName("type")]
    public DbTypes Type { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}