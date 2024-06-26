using System.CommandLine;

namespace Tada.Cli.Commands;

public class RevertMigrationSubCommand : Command
{
    public RevertMigrationSubCommand() : base("revert", "Revert migration on database")
    {
        var name = new Argument<string>
            ("name", "Migration name");

        this.Add(name);

        this.SetHandler((nameValue) => Execute(nameValue), name);
    }
    public void Execute(string name)
    {
        var config = ConfigurationLoader.LoadTadaFile();
        string ns = (config?.Namespace ?? "tada")!;

        ConsoleWriter.Start("Updating Database");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"ef database update {name}", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("Database Updated");
    }
}