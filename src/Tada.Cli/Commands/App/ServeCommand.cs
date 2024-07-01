using System.CommandLine;

namespace Tada.Cli.Commands.App;

public class ServeCommand: Command
{
    public ServeCommand() : base("serve", "starts app in hot reload mode")
    {
        this.SetHandler(() => Execute());
    }

    public void Execute()
    {
        var config = ConfigurationLoader.LoadTadaFile();
        string ns = (config?.Namespace ?? "tada")!;

        ConsoleWriter.Start("Starting database container");

        var shell = new ProcessShell();
        shell.Execute("docker", "compose up -d");
        
        ConsoleWriter.Start("Serving app");
        shell.Execute("dotnet", $"watch run --project \"./src/4.Presentation/{ns}.Presentation.Api/{ns}.Presentation.Api.csproj\"");
        
        ConsoleWriter.Success("app stopped");
    }
}