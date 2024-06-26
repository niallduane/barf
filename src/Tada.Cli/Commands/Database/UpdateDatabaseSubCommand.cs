using System.CommandLine;

namespace Tada.Cli.Commands;

public class UpdateDatabaseSubCommand : Command
{
    public UpdateDatabaseSubCommand() : base("update", "runs the migrations against the database")
    {
        this.SetHandler(() => Execute());
    }
    public void Execute()
    {
        var config = ConfigurationLoader.LoadTadaFile();
        string ns = (config?.Namespace ?? "tada")!;

        ConsoleWriter.Start("Updating Database");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"ef database update", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("Database Updated");
    }
}