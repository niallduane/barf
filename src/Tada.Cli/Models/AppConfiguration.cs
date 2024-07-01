using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tada.Cli.Types;
using System.Text.Json.Serialization;

namespace Tada.Cli.Models;

public class AppConfiguration
{
    [JsonPropertyName("package")]
    public PackageConfiguration Package {get;set;} = new();
}

public class PackageConfiguration
{
    [JsonPropertyName("folder")]
    public string Folder {get;set;} = "./publish";
    [JsonPropertyName("architecture")]
    public ArchitectureTypes Architecture {get; set; } = ArchitectureTypes.LinuxArm64;
}