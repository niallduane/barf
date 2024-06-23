using System.CommandLine;

namespace Barf.Cli.Commands.Add;



public class AddServiceSubCommand : Command
{
    public enum ServiceTemplateTypes
    {
        Basic = 0,
        Full = 2
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
        var config = ConfigurationLoader.LoadBarfFile();
        var ns = config?.Namespace ?? "barf";


        ConsoleWriter.Start("Adding barf service");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"new barf-domain-service -n {name} --nameSpace {ns}");
        shell.Execute("dotnet", $"new barf-service-controller -n {name} --nameSpace {ns}");

        if (serviceType == ServiceTemplateTypes.Full)
        {
            shell.Execute("dotnet", $"new barf-database-entity -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

            shell.Execute("dotnet", $"new barf-database-repository -n {name} --nameSpace {ns} -o \"./src/2.Infrastructure/Database/\"");

            shell.Execute("dotnet", $"new barf-service-full -n {name} --nameSpace {ns}");

            AddEntitySubCommand.UpdateContent(name, ns);
            AddRepositorySubCommand.UpdateContent(name, ns);
        }
        else
        {
            shell.Execute("dotnet", $"new barf-service-basic -n {name} --nameSpace {ns}");
        }

        UpdateContent(name, ns);

        shell.DotnetFormat();

        ConsoleWriter.Success("barf service added");
    }

    public static void UpdateContent(string name, string nameSpace)
    {
        var serviceRegistration = Path.Combine(Directory.GetCurrentDirectory(), $"src/3.Services/{nameSpace}.Services/DependencyRegistration.cs");
        FileUpdater.UpdateContent(serviceRegistration,
        @"// <!-- barf injection token -->",
        $@"// <!-- barf injection token -->
        services.AddTransient<Domain.Services.{name}s.I{name}Service, {name}s.{name}Service>();
        ");
    }
}