using System.CommandLine;
using System.Reflection;
using Tada.Cli.Types;
using Tada.Cli.Extensions;

namespace Tada.Cli.Commands.Add;

public class AddDeploymentStackSubCommand : Command
{
    public AddDeploymentStackSubCommand() : base("stack", "add deployment stack using Pulumi")
    {
        var stackType = new Option<StackTypes>("--type", () => StackTypes.Azure, "Select the stack type");

        this.Add(stackType);

        this.SetHandler((stackTypeValue) => Execute(stackTypeValue), stackType);
    }

    public void Execute(StackTypes stackType)
    {
        var config = ConfigurationLoader.LoadTadaFile();
        var ns = config?.Namespace ?? "tada";


        ConsoleWriter.Start($"Adding {stackType} deployment stack");

        var shell = new ProcessShell();

        shell.Execute(Assembly.GetExecutingAssembly().GetResourceText("Scripts.AddDeploymentStack.ps1")
            .Replace("$SOLUTION_NAME", ns));

        shell.DeleteFileInSubDirectories("Program.cs");
        
        var workingDirectory = $"./src/2.Infrastructure/DeploymentStack/{ns}.Infrastructure.DeploymentStack/";
        if (stackType == StackTypes.Azure)
        {
            var azureScript = $@"
dotnet add ""./src/2.Infrastructure/DeploymentStack/{ns}.Infrastructure.DeploymentStack/{ns}.Infrastructure.DeploymentStack.csproj"" package Pulumi.AzureNative;
dotnet new tada-stack-azure --nameSpace {ns};
            ";
            shell.Execute(azureScript);
            config.App.Stack = StackTypes.Azure;
        }
        else if (stackType == StackTypes.AWS)
        {
            var awsScript = $@"
dotnet add ""./src/2.Infrastructure/DeploymentStack/{ns}.Infrastructure.DeploymentStack/{ns}.Infrastructure.DeploymentStack.csproj"" package Pulumi.Aws;
dotnet new tada-stack-aws --nameSpace {ns};
            ";
            shell.Execute(awsScript);
            config.App.Stack = StackTypes.AWS;
        }

        
        AddDeploymentStackSubCommand.UpdateContent(ns);

        ConfigurationLoader.Update(config);

        shell.DotnetFormat();

        ConsoleWriter.Success($"{stackType} deployment stack added");
        ConsoleWriter.Standard("Next Steps:", 
            "Execute the pulumi cli command `pulumi stack init dev`",
            "To create a production stack `pulumi stack init prod`"
        );
    }

    public static void UpdateContent(string nameSpace)
    {
        
    }
}