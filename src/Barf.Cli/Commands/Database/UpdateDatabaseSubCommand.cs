using System.CommandLine;

namespace Barf.Cli.Commands;

public class UpdateDatabaseSubCommand : Command
{
    public UpdateDatabaseSubCommand() : base("update")
    {
        this.SetHandler(() => Execute());
    }
    public void Execute()
    {
        var config = ConfigurationLoader.LoadBarfFile();
        string ns = (config?.Namespace ?? "barf")!;

        ConsoleWriter.Start("Updating Database");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"ef database update", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("Database Updated");
    }
}