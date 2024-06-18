using System.Reflection;

namespace Barf.Cli.Extensions;

public static class AssemblyExtensions
{
    public static string GetResourceText(this Assembly assembly, string resourceName)
    {
        var resource = $"{assembly.GetName().Name}.{resourceName}";
        using Stream stream = assembly.GetManifestResourceStream(resource)!;
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }
}