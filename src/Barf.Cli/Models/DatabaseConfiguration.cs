using System.Text.Json.Serialization;

using Barf.Cli.Types;

namespace Barf.Cli.Models;

public class DatabaseConfiguration
{
    [JsonPropertyName("type")]
    public DbType Type { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}