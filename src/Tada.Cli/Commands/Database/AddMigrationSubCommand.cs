using System.CommandLine;

namespace Tada.Cli.Commands;

public class AddMigrationSubCommand : Command
{
    public AddMigrationSubCommand() : base("add", "Add new database migration")
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

        ConsoleWriter.Start("Adding migration");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"ef migrations add {name}", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("migration added");
    }
}