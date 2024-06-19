using System.Text.Json.Serialization;

using Barf.Cli.Types;

namespace Barf.Cli.Models;

public class DatabaseConfiguration
{
    [JsonPropertyName("type")]
    public DbType Type { get; set; }
}