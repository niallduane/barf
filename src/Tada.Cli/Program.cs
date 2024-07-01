using System.CommandLine;

using Tada.Cli;
using Tada.Cli.Commands;
using Tada.Cli.Commands.Add;
using Tada.Cli.Commands.App;
using Tada.Cli.Commands.Database;

public class Program
{
    public const string ToolName = "tada";
    public static async Task Main(string[] args)
    {
        var app = new RootCommand();
        app.AddCommand(new InstallCommand());
        app.AddCommand(new UninstallCommand());
        app.AddCommand(new NewSolutionCommand());
        app.AddCommand(new AddCommand());
        app.AddCommand(new DBCommand());
        app.AddCommand(new AppCommand());

        try
        {
            await app.InvokeAsync(args);
        }
        catch (Exception ex)
        {
            ConsoleWriter.Error(ex.Message);
        }
    }
}