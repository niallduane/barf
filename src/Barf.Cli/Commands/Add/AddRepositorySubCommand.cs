using System.CommandLine;
using System.Diagnostics;

namespace Barf.Cli.Commands.Add;

public class AddRepositorySubCommand : Command
{
    public AddRepositorySubCommand() : base("repository", "add repository code")
    {
        var name = new Argument<string>
            ("name", "Repository name");

        this.Add(name);

        this.SetHandler((nameValue) => Execute(nameValue), name);
    }

    public void Execute(string name)
    {
        var config = ConfigurationLoader.LoadBarfFile();
        var ns = config?.Namespace ?? "barf";

        ConsoleWriter.Start("Adding barf repository");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"new barf-database-repository -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

        UpdateContent(name, ns);

        shell.DotnetFormat();

        ConsoleWriter.Success("barf repository added");
    }

    public static void UpdateContent(string name, string nameSpace)
    {
        var repositoryRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/2.Infrastructure/Database/{nameSpace}.Infrastructure.Database.Repositories/DependencyRegistration.cs");
        FileUpdater.UpdateContent(repositoryRegistration,
        @"public static void RegisterRepositories(this IServiceCollection services, IConfiguration config)
    {",
        $@"public static void RegisterRepositories(this IServiceCollection services, IConfiguration config)
    {{
        services.AddTransient<{name}s.I{name}Repository, {name}s.{name}Repository>();
            ");
    }
}