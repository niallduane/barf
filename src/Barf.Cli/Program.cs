using System.CommandLine;

using Barf.Cli;
using Barf.Cli.Commands;
using Barf.Cli.Commands.Add;
using Barf.Cli.Commands.Database;

public class Program
{
    public const string ToolName = "barf";
    public static async Task Main(string[] args)
    {
        var app = new RootCommand();
        app.AddCommand(new InstallCommand());
        app.AddCommand(new UninstallCommand());
        app.AddCommand(new NewSolutionCommand());
        app.AddCommand(new AddCommand());
        app.AddCommand(new DBCommand());

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