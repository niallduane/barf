using System.CommandLine;

namespace Tada.Cli.Commands.App;

public class PackageCommand: Command
{
    public PackageCommand() : base("package", "create a deployment package")
    {
        this.SetHandler(() => Execute());
    }

    public void Execute()
    {
        var config = ConfigurationLoader.LoadTadaFile()!;
        var ns = config.Namespace;

        var appPackage = $"{config?.App.Package.Folder}/app";
        var dbPackage = $"{config?.App.Package.Folder}/dbmigrations";
        var architectureType = "";
        
        switch (config?.App.Package.Architecture)
        {
            case Types.ArchitectureTypes.LinuxX64: 
                architectureType = "linux-x64";
                break;
            case Types.ArchitectureTypes.LinuxArm64: 
                architectureType = "linux-arm64";
                break;
            case Types.ArchitectureTypes.WinX86: 
                architectureType = "win-x86";
                break;
            default: 
                architectureType = "win-x64";
                break;
        };

        ConsoleWriter.Start("Creating deployment package");

        var shell = new ProcessShell();
        shell.Execute("dotnet", $"publish \"./src/4.Presentation/{ns}.Presentation.Api/{ns}.Presentation.Api.csproj\" -o \"{appPackage}\" --configuration Release --self-contained -r {architectureType}");

        shell.Execute("dotnet", $"ef migrations bundle --startup-project \"./src/2.Infrastructure/Database/{ns}.Infrastructure.Database/{ns}.Infrastructure.Database.csproj\" --output \"{dbPackage}\" --force --self-contained -r {architectureType}");

        ConsoleWriter.Success("Deployment package created");
    }
}