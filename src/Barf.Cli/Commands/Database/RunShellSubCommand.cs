using System.CommandLine;
using System.Diagnostics;

using Barf.Cli.Types;

namespace Barf.Cli.Commands;

public class RunShellSubCommand : Command
{
    public RunShellSubCommand() : base("shell")
    {
        this.SetHandler(() => Execute());
    }
    public void Execute()
    {
        var config = ConfigurationLoader.LoadBarfFile();
        string ns = (config?.Namespace ?? "barf")!;

        ConsoleWriter.Start("Starting database shell");

        var shell = new ProcessShell();
        if (config.Database.Type == DbType.Mysql)
        {
            shell.Execute("docker", $"compose exec {config.Database.ContainerId} mysql -u root -pP@ssw0rd {config.Database.Name}");
            ConsoleWriter.Success("Database shell closed");
        }
        else if (config.Database.Type == DbType.Postgres)
        {
            shell.Execute("docker", $"compose exec {config.Database.ContainerId} psql -U root -d {config.Database.Name}");
            ConsoleWriter.Success("Database shell closed");
        }
        else if (config.Database.Type == DbType.SqlServer)
        {
            ConsoleWriter.Warning("You must use Sqlcmd to access database");
            ConsoleWriter.Warning("For more info:")
            ConsoleWriter.Warning("https://techcommunity.microsoft.com/t5/sql-server-blog/use-sqlcmd-to-create-and-query-a-sql-server-container-for/ba-p/3859167#:~:text=The%20prerequisite%20to%20use%20sqlcmd,such%20as%20Docker%20or%20Podman.&text=If%20you%20have%20the%20ODBC,sqlcmd%20to%20become%20the%20default.");
        }
    }
}