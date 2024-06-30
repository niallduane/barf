using System.CommandLine;

using Tada.Cli.Types;

namespace Tada.Cli.Commands;

public class RunShellSubCommand : Command
{
    public RunShellSubCommand() : base("shell", "creates a shell for executing sql commands against the database")
    {
        this.SetHandler(() => Execute());
    }
    public void Execute()
    {
        var config = ConfigurationLoader.LoadTadaFile();
        string ns = (config?.Namespace ?? "tada")!;

        ConsoleWriter.Start("Starting database shell");

        var shell = new ProcessShell();
        shell.Execute("docker", "compose up -d");
        if (config?.Database?.Type == DbType.Mysql)
        {
            shell.Execute("docker", $"compose exec {config.Database.ContainerId} mysql -u {config.Database.Username} -p{config.Database.Password} {config.Database.Name}");
            ConsoleWriter.Success("Database shell closed");
        }
        else if (config?.Database?.Type == DbType.Postgres)
        {
            shell.Execute("docker", $"compose exec {config.Database.ContainerId} psql -U {config.Database.Username} -d {config.Database.Name}");
            ConsoleWriter.Success("Database shell closed");
        }
        else if (config?.Database?.Type == DbType.SqlServer)
        {
            shell.Execute("docker", $"compose exec {config.Database.ContainerId} /opt/mssql-tools/bin/sqlcmd -S localhost -U {config.Database.Username} -P {config.Database.Password}  -d {config.Database.Name}");
            ConsoleWriter.Success("Database shell closed");
        }
    }
}