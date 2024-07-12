using System.CommandLine;

namespace Tada.Cli.Commands.Add;



public class AddServiceSubCommand : Command
{
    public enum ServiceTemplateTypes
    {
        Basic = 1,
        ExcludeEntity = 2,
        Full = 3
    }
    public AddServiceSubCommand() : base("service", "add service code")
    {
        var name = new Argument<string>
            ("name", "Service name");

        var templateType = new Option<ServiceTemplateTypes>("--type", () => ServiceTemplateTypes.Basic, "Select the service type");

        this.Add(name);
        this.Add(templateType);

        this.SetHandler((nameValue, templateTypeValue) => Execute(nameValue, templateTypeValue), name, templateType);
    }

    public void Execute(string name, ServiceTemplateTypes serviceType)
    {
        var config = ConfigurationLoader.LoadTadaFile();
        var ns = config?.Namespace ?? "tada";


        ConsoleWriter.Start($"Adding {name} service");

        var shell = new ProcessShell();
        shell.Execute("dotnet", "new install Tada.TemplatePack");
        shell.Execute("dotnet", $"new tada-domain-service -n {name} --nameSpace {ns}");
        shell.Execute("dotnet", $"new tada-service-controller -n {name} --nameSpace {ns}");

        if (serviceType == ServiceTemplateTypes.Full)
        {
            shell.Execute("dotnet", $"new tada-database-entity -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

            shell.Execute("dotnet", $"new tada-database-repository -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

            shell.Execute("dotnet", $"new tada-service-full -n {name} --nameSpace {ns}");

            AddEntitySubCommand.UpdateContent(name, ns);
            AddRepositorySubCommand.UpdateContent(name, ns);
        }
        else if (serviceType == ServiceTemplateTypes.ExcludeEntity )
        {
            shell.Execute("dotnet", $"new tada-database-repository -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

            shell.Execute("dotnet", $"new tada-service-full -n {name} --nameSpace {ns}");

            AddEntitySubCommand.UpdateContent(name, ns);
            AddRepositorySubCommand.UpdateContent(name, ns);
        }
        else
        {
            shell.Execute("dotnet", $"new tada-service-basic -n {name} --nameSpace {ns}");
        }

        UpdateContent(name, ns);

        shell.DotnetFormat();

        ConsoleWriter.Success($"{name} service added");
    }

    public static void UpdateContent(string name, string nameSpace)
    {
        var serviceRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/3.Services/{nameSpace}.Services/DependencyRegistration.cs");
        FileUpdater.UpdateContent(serviceRegistration,
        @"// <!-- tada injection token -->",
        $@"// <!-- tada injection token -->
        services.AddTransient<Domain.Services.{name}s.I{name}Service, {name}s.{name}Service>();
        ");
    }
}