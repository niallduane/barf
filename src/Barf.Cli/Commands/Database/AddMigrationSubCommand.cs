using System.CommandLine;
using System.Diagnostics;

namespace Barf.Cli.Commands;

public class AddMigrationSubCommand : Command
{
    public AddMigrationSubCommand() : base("add")
    {
        var name = new Argument<string>
            ("name", "Migration name");

        this.Add(name);

        this.SetHandler((nameValue) => Execute(nameValue), name);
    }
    public void Execute(string name)
    {
        var config = ConfigurationLoader.LoadBarfFile();
        string ns = (config?.Namespace ?? "barf")!;

        ConsoleWriter.Start("Adding migration");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"ef migrations add {name}", $"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database");

        ConsoleWriter.Success("migration added");
    }
}