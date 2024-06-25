using System.CommandLine;

namespace Barf.Cli.Commands;

public class UninstallCommand : Command
{
    public UninstallCommand() : base("uninstall", "uninstalls the barf templates")
    {
        this.SetHandler(Execute);
    }
    const string TemplatePackage = "Barf.TemplatePack";

    public static void Execute()
    {
        ConsoleWriter.Start("Uninstalling Template Pack");
        var shell = new ProcessShell();
        shell.Execute("dotnet", $"new uninstall {TemplatePackage}");
        ConsoleWriter.Success("Template Pack uninstalled");
    }
}