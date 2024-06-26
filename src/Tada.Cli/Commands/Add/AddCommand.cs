using System.CommandLine;

namespace Tada.Cli.Commands.Add;

public class AddCommand : Command
{
    public AddCommand() : base("add")
    {
        this.AddCommand(new AddEntitySubCommand());
        this.AddCommand(new AddInfrastructureSubCommand());
        this.AddCommand(new AddRepositorySubCommand());
        this.AddCommand(new AddServiceSubCommand());
    }
}