using System.CommandLine;

namespace Tada.Cli.Commands.Add;

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
        var config = ConfigurationLoader.LoadTadaFile();
        string ns = (config?.Namespace ?? "tada")!;

        ConsoleWriter.Start($"Adding {name} entity");

        var shell = new ProcessShell();
        shell.Execute("dotnet", "new install Tada.TemplatePack");
        shell.Execute("dotnet", $"new tada-database-entity -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\" --idType \"{config?.Templates.Entity.IdType}\" --idTypeNameSpace \"{config?.Templates.Entity.IdTypeNameSpace}\"");

        UpdateContent(name, ns);

        shell.DotnetFormat();

        ConsoleWriter.Success($"{name} entity added");
    }

    public static void UpdateContent(string name, string nameSpace)
    {
        var entityRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/2.Infrastructure/Database/{nameSpace}.Infrastructure.Database/DatabaseContext.cs");
        FileUpdater.UpdateContent(entityRegistration, new Dictionary<string, string>() {
            {
        @"// <!-- tada injection token -->",
        $@"// <!-- tada injection token -->
    public DbSet<{name}> {name}s => Set<{name}>();
"
            }
        });

        FileUpdater.AddContentToBeginningOfFile(entityRegistration,
    $@"using {nameSpace}.Infrastructure.Database.Entities;
");

        var entityFactoryRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/2.Infrastructure/Database/{nameSpace}.Infrastructure.Database.Tests/InMemoryDatabaseContext.cs");
        FileUpdater.UpdateContent(entityFactoryRegistration, new Dictionary<string, string>() {
            {
        @"// <!-- tada injection token -->",
        $@"// <!-- tada injection token -->
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