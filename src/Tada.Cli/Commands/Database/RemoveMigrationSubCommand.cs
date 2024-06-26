using System.CommandLine;

namespace Tada.Cli.Commands;

public class RemoveMigrationSubCommand : Command
{
    public RemoveMigrationSubCommand() : base("remove", "Remove last migration in codebase")
    {
        this.SetHandler(() => Execute());
    }
    public void Execute()
    {
        var config = ConfigurationLoader.LoadTadaFile();
        string ns = (config?.Namespace ?? "tada")!;

        ConsoleWriter.Start("Updating Database");

        var shell = new ProcessShell();
        shell.Execute("dotnet", "ef database remove", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("Database Updated");
    }
}