using System.CommandLine;

namespace Tada.Cli.Commands.Add;

public class AddCommand : Command
{
    public AddCommand() : base("add", "add functionality to a tada solution")
    {
        this.AddCommand(new AddEntitySubCommand());
        this.AddCommand(new AddInfrastructureSubCommand());
        this.AddCommand(new AddRepositorySubCommand());
        this.AddCommand(new AddServiceSubCommand());
        this.AddCommand(new AddDeploymentStackSubCommand());
    }
}