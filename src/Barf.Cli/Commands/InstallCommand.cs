using System.CommandLine;
using System.Diagnostics;

namespace Barf.Cli.Commands;

public class InstallCommand : Command
{
    public InstallCommand() : base("install")
    {
        this.SetHandler(Execute);
    }

    public void Execute()
    {
        ConsoleWriter.Start("Installing Barf Templates");

        var shell = new ProcessShell();
        shell.Execute("dotnet", "new install Barf.TemplatePack");

        ConsoleWriter.Success("Barf Templates Install");
    }
}