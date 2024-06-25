using System.CommandLine;

namespace Barf.Cli.Commands.Database;

public class DBCommand : Command
{
    public DBCommand() : base("db", "database commands")
    {
        this.AddCommand(new AddMigrationSubCommand());
        this.AddCommand(new UpdateDatabaseSubCommand());
        this.AddCommand(new RunShellSubCommand());
    }
}