using System.CommandLine;

namespace Barf.Cli.Commands.Add
{
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
}