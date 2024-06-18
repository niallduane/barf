using System.CommandLine;
using System.Diagnostics;
using System.Reflection;

using Barf.Cli.Extensions;

namespace Barf.Cli.Commands;

public class NewSolutionCommand : Command
{
    public enum DbType
    {
        Mysql = 0,
        SqlServer = 1,
        Postgres = 2,
    }
    public NewSolutionCommand() : base("new", "creates a new barf solution")
    {
        var name = new Argument<string>
            ("name", "solution name");

        var dbType = new Option<DbType>("--dbtype", () => DbType.SqlServer, "Select the db type");

        this.Add(name);
        this.Add(dbType);

        this.SetHandler((nameValue, dbTypeValue) => Execute(nameValue, dbTypeValue), name, dbType);
    }

    public void Execute(string solutionName, DbType dbType)
    {
        ConsoleWriter.Start("Creating Project");
        if (string.IsNullOrEmpty(solutionName))
        {
            ConsoleWriter.Error("name is required");
        }

        var shell = new ProcessShell();
        shell.Execute(Assembly.GetExecutingAssembly().GetResourceText("Scripts.NewSolution.ps1")
            .Replace("$SOLUTION_NAME", solutionName));

        if (dbType == DbType.Mysql)
        {
            shell.Execute(Assembly.GetExecutingAssembly().GetResourceText("Scripts.AddMySql.ps1")
                .Replace("$SOLUTION_NAME", solutionName));

            shell.Execute("dotnet", $"user-secrets set \"ConnectionStrings:Database\" \"server=localhost;port=3308;database={solutionName};uid=root;pwd=P@ssw0rd;ConvertZeroDateTime=True\" -p \"./src/2.Infrastructure/Database/{solutionName}.Infrastructure.Database/{solutionName}.Infrastructure.Database.csproj\"");
        }
        else if (dbType == DbType.Postgres)
        {
            shell.Execute(Assembly.GetExecutingAssembly().GetResourceText("Scripts.AddPostgres.ps1")
                .Replace("$SOLUTION_NAME", solutionName));

            shell.Execute("dotnet", $"user-secrets set \"ConnectionStrings:Database\" \"Server=localhost;Port=3308;Database={solutionName};Username=root;Password=P@ssw0rd;\" -p \"./src/2.Infrastructure/Database/{solutionName}.Infrastructure.Database/{solutionName}.Infrastructure.Database.csproj\"");
        }
        else
        {
            shell.Execute(Assembly.GetExecutingAssembly().GetResourceText("Scripts.AddSqlServer.ps1")
                .Replace("$SOLUTION_NAME", solutionName));

            shell.Execute("dotnet", $"user-secrets set \"ConnectionStrings:Database\" \"Server=localhost,1401;Database={solutionName};User Id=sa;Password=P@ssw0rd;\" -p \"./src/2.Infrastructure/Database/{solutionName}.Infrastructure.Database/{solutionName}.Infrastructure.Database.csproj\"");
        }

        shell.DeleteFileInSubDirectories("Class1.cs");
        shell.DeleteFileInSubDirectories("UnitTest1.cs");
        shell.DeleteFileInSubDirectories("WeatherForecastController.cs");
        shell.DeleteFileInSubDirectories("WeatherForecast.cs");
        shell.DeleteFileInSubDirectories("Worker.cs");

        var apiProgramFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"src/4.Presentation/{solutionName}.Presentation.Api/Program.cs");
        FileUpdater.UpdateContent(apiProgramFilePath,
            new Dictionary<string, string>()
        {
            {
                "var builder = WebApplication.CreateBuilder(args);",
                @$"
using {solutionName}.Presentation.Api.Filters;
using {solutionName}.Presentation.Api.Startup;
var builder = WebApplication.CreateBuilder(args);"
            },
            {
                "builder.Services.AddControllers();",
                @"
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionHandlerFilter>();
    options.Filters.Add<ModelStateFilter>();
});

builder.Services.Register(builder.Configuration);
        "
            },
            {
                "builder.Services.AddEndpointsApiExplorer();",
                "builder.Services.RegisterSwagger(builder.Configuration);"
            },
            {
                "builder.Services.AddSwaggerGen();",
                ""
            },
            {
                "app.Run();",
                @"
app.RegisterMiddleware();

app.Run();
        "
            }
        });

        var apiProjFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"src/4.Presentation/{solutionName}.Presentation.Api/{solutionName}.Presentation.Api.csproj");

        FileUpdater.UpdateContent(apiProjFilePath, "</Project>", @"
	<PropertyGroup>
		<GenerateDocumentationFile>true</GenerateDocumentationFile>
		<NoWarn>$(NoWarn);1591</NoWarn>
	</PropertyGroup>
</Project>
        ");

        var editorConfigPath = Path.Combine(Directory.GetCurrentDirectory(), $".editorconfig");

        FileUpdater.UpdateContent(editorConfigPath, "[*.cs]", @"
[*.cs]
csharp_style_namespace_declarations = file_scoped:error
dotnet_diagnostic.IDE0005.severity = warning

# private fields naming rules
dotnet_naming_rule.private_members_with_underscore.symbols  = private_fields
dotnet_naming_rule.private_members_with_underscore.style    = prefix_underscore
dotnet_naming_rule.private_members_with_underscore.severity = warning

dotnet_naming_symbols.private_fields.applicable_kinds           = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private

dotnet_naming_style.prefix_underscore.capitalization = camel_case
dotnet_naming_style.prefix_underscore.required_prefix = _
        ");

        FileUpdater.UpdateContent(editorConfigPath, "end_of_line = crlf", @"end_of_line = lf");

        shell.DotnetFormat();

        ConsoleWriter.Success("Project Created");
    }
}