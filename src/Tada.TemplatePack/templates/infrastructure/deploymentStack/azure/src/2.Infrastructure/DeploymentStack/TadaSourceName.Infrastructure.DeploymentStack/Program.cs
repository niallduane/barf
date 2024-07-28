using Pulumi;

using TadaSourceName.Infrastructure.DeploymentStack.Components;

return await Deployment.RunAsync(() =>
{
    var resourceGroup = new Pulumi.AzureNative.Resources.ResourceGroup($"tadasourcename-rg");

    var database = new DatabaseComponent("tadasourcename", resourceGroup);
    var app = new AppComponent("tadasourcename", resourceGroup, database.ConnectionString);

    return new Dictionary<string, object?>
    {
        { "resourceName", resourceGroup.Name },
        { "resourceLocation", resourceGroup.Location },
        { "connectionString", database.ConnectionString },
        { "url", app.Url },
        { "webHostUrl", app.WebHostUrl }
    };
});