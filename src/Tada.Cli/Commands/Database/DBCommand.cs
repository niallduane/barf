using System.CommandLine;

namespace Tada.Cli.Commands.Database;

public class DBCommand : Command
{
    public DBCommand() : base("db")
    {
        this.AddCommand(new AddMigrationSubCommand());
        this.AddCommand(new UpdateDatabaseSubCommand());
        this.AddCommand(new RunShellSubCommand());
    }
}