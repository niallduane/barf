using System.CommandLine;

namespace Tada.Cli.Commands;

public class UninstallCommand : Command
{
    public UninstallCommand() : base("uninstall")
    {
        this.SetHandler(Execute);
    }
    const string TemplatePackage = "Tada.TemplatePack";

    public static void Execute()
    {
        ConsoleWriter.Start("Uninstalling Template Pack");
        var shell = new ProcessShell();
        shell.Execute("dotnet", $"new uninstall {TemplatePackage}");
        ConsoleWriter.Success("Template Pack uninstalled");
    }
}