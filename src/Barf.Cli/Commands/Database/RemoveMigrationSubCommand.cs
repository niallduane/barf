using System.CommandLine;

namespace Barf.Cli.Commands;

public class RemoveMigrationSubCommand : Command
{
    public RemoveMigrationSubCommand() : base("remove", "Remove last migration in codebase")
    {
        this.SetHandler(() => Execute());
    }
    public void Execute()
    {
        var config = ConfigurationLoader.LoadBarfFile();
        string ns = (config?.Namespace ?? "barf")!;

        ConsoleWriter.Start("Updating Database");

        var shell = new ProcessShell();
        shell.Execute("dotnet", "ef database remove", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("Database Updated");
    }
}