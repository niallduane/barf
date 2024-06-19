using System.CommandLine;

namespace Barf.Cli.Commands.Add;

public class AddEntitySubCommand : Command
{
    public AddEntitySubCommand() : base("entity", "Add a database entity")
    {
        var name = new Argument<string>
            ("name", "entity name");

        this.Add(name);

        this.SetHandler((nameValue) => Execute(nameValue), name);
    }
    public void Execute(string name)
    {
        var config = ConfigurationLoader.LoadBarfFile();
        string ns = (config?.Namespace ?? "barf")!;

        ConsoleWriter.Start("Updating Database");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"new barf-database-entity -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

        UpdateContent(name, ns);

        shell.DotnetFormat();

        ConsoleWriter.Success("Database Updated");
    }

    public static void UpdateContent(string name, string nameSpace)
    {
        var entityRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/2.Infrastructure/Database/{nameSpace}.Infrastructure.Database/DatabaseContext.cs");
        FileUpdater.UpdateContent(entityRegistration, new Dictionary<string, string>() {
            {
        @"public class DatabaseContext : DbContext
{", $@"public class DatabaseContext : DbContext
{{
    public virtual DbSet<{name}> {name}s {{ get; set; }}
"
            }
        });

        FileUpdater.AddContentToBeginningOfFile(entityRegistration,
    $@"using {nameSpace}.Infrastructure.Database.Entities;
");

        var entityFactoryRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/2.Infrastructure/Database/{nameSpace}.Infrastructure.Database.Tests/InMemoryDatabaseContext.cs");
        FileUpdater.UpdateContent(entityFactoryRegistration, new Dictionary<string, string>() {
            {
@"private void Seed()
    {", $@"private void Seed()
    {{
        this.{name}s.AddRange(new {name}Factory().Generate(100));
"
            }

        });

        FileUpdater.AddContentToBeginningOfFile(entityFactoryRegistration,
$@"using {nameSpace}.Infrastructure.Database.Tests.Factories;
"
        );
    }
}