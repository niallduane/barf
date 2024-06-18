using System.CommandLine;
using System.Diagnostics;
using System.Reflection;

using Barf.Cli.Extensions;

namespace Barf.Cli.Commands.Add;

public class AddInfrastructureSubCommand : Command
{
    public AddInfrastructureSubCommand() : base("infrastructure", "add infrastructure projects")
    {
        var name = new Argument<string>
            ("name", "Infrastructure name");

        this.Add(name);

        this.SetHandler((nameValue) => Execute(nameValue), name);
    }

    public void Execute(string name)
    {
        var config = ConfigurationLoader.LoadBarfFile();
        var ns = config?.Namespace ?? "barf";


        ConsoleWriter.Start("Adding barf infrastructure");

        var shell = new ProcessShell();

        shell.Execute(Assembly.GetExecutingAssembly().GetResourceText("Scripts.NewInfrastructure.ps1")
            .Replace("$SOLUTION_NAME", ns)
            .Replace("$INFRA_NAME", name));

        shell.DeleteFileInSubDirectories("Class1.cs");
        shell.DeleteFileInSubDirectories("UnitTest1.cs");
        shell.Execute("dotnet", "new barf-infra -n \"{name}\" --nameSpace \"{ns}\"");

        shell.DotnetFormat();

        ConsoleWriter.Success("barf infrastructure added");
    }
}