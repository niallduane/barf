using System.CommandLine;

namespace Tada.Cli.Commands.App;

public class AppCommand : Command
{
    public AppCommand() : base("app", "app commands")
    {
        this.AddCommand(new PackageCommand());
        this.AddCommand(new ServeCommand());
    }
}