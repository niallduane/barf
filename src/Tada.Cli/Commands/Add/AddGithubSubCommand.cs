using System.CommandLine;

namespace Tada.Cli.Commands.Add;

public class AddGithubSubCommand : Command
{
    public AddGithubSubCommand() : base("github", "add github workflows and templates")
    {
        this.SetHandler(Execute);
    }

    public void Execute()
    {
        var config = ConfigurationLoader.LoadTadaFile();
        var ns = config?.Namespace ?? "tada";

        var shell = new ProcessShell();
        shell.Execute("dotnet", "new install Tada.TemplatePack");
        shell.Execute("dotnet", $"new tada-sln-github --nameSpace {ns}");

        ConsoleWriter.Success($"github workflows and templates added");
    }
}