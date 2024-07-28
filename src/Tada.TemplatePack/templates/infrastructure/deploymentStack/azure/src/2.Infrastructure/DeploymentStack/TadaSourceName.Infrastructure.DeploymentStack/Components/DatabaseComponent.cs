using Pulumi;
using Pulumi.AzureNative.Sql;
using Pulumi.AzureNative.Resources;

namespace TadaSourceName.Infrastructure.DeploymentStack.Components;

class DatabaseComponent : ComponentResource
{
    public Output<string> ConnectionString { get; private set; }

    public DatabaseComponent(string name, ResourceGroup resourceGroup, ComponentResourceOptions? opts = null)
        : base("custom:resource:SqlServerComponent", name, opts)
    {
        var config = new Pulumi.Config();

        var password = config.Require("sqlAdminPassword");
        var sqlServer = new Server($"{name}-sqlserver", new ServerArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ServerName = $"{name}-sqlserver",
            Location = resourceGroup.Location,
            AdministratorLogin = "sqladmin",
            AdministratorLoginPassword = password,
            Version = "12.0"
        });

        var database = new Database($"{name}-db", new DatabaseArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ServerName = sqlServer.Name,
            DatabaseName = $"{name}-db"
        });

        ConnectionString = Output.Format($"Server={sqlServer.FullyQualifiedDomainName};Database={database.Name};User ID={sqlServer.AdministratorLogin};Password={password};");

        // Registering outputs for this component
        this.RegisterOutputs(new Dictionary<string, object?>
        {
            { "connectionString", this.ConnectionString }
        });
    }
}