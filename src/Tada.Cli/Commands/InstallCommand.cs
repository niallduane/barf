using System.CommandLine;

namespace Tada.Cli.Commands;

public class InstallCommand : Command
{
    public InstallCommand() : base("install")
    {
        this.SetHandler(Execute);
    }

    public void Execute()
    {
        ConsoleWriter.Start("Installing Tada Templates");

        var shell = new ProcessShell();
        shell.Execute("dotnet", "new install Tada.TemplatePack");

        ConsoleWriter.Success("Tada Templates Install");
    }
}