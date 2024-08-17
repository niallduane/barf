using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;

namespace TadaSourceName.Infrastructure.DeploymentStack.Components;

public class AppComponent : ComponentResource
{
    public Output<string> WebHostUrl { get; private set; }
    public Output<string> Url { get; private set; }

    public AppComponent(string name, ComponentResourceOptions? opts = null)
        : base("custom:resource:AppComponent", name, opts)
    {
        // Create an App Service Plan
        var appServicePlan = new AppServicePlan("appServicePlan", new AppServicePlanArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = new SkuDescriptionArgs
            {
                Name = "F1",
                Tier = "Free"
            }
        });

        // Create a Web App with connection string to SQL Database
        var webApp = new WebApp("webApp", new WebAppArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            ServerFarmId = appServicePlan.Id,
            SiteConfig = new SiteConfigArgs
            {
                ConnectionStrings = new InputList<ConnStringInfoArgs>
                {
                    new ConnStringInfoArgs
                    {
                        Name = "Database",
                        ConnectionString = Output.Tuple(sqlServer.Name, sqlDatabase.Name)
                            .Apply(t => $"Server=tcp:{t.Item1}.database.windows.net,1433;Initial Catalog={t.Item2};Persist Security Info=False;User ID=sqladmin;Password={sqlAdminPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"),
                        Type = ConnectionStringType.SQLAzure
                    }
                }
            }
        });


        // Create a DNS Zone
        var dnsZone = new Zone("tadaSourceNameZone", new ZoneArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ZoneName = config.Require("domainName")
        });

        // Create a CName Record to point to the web app
        var cnameRecord = new CNameRecordSet("tadaSourceNameDnsRecord", new CNameRecordSetArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ZoneName = dnsZone.Name,
            RelativeRecordSetName = "www",
            RecordType = "CNAME",
            Ttl = 300,
            CnameRecord = new CNameRecordArgs
            {
                Cname = webApp.DefaultHostName.Apply(hostname => hostname)
            }
        });
        this.WebHostUrl = webApp.DefaultHostName.Apply(hostname => $"https://{hostname}");
        this.Url = Output.Format($"https://{cnameRecord.RelativeRecordSetName}.{dnsZone.ZoneName}");

        this.RegisterOutputs(new Dictionary<string, object?>
        {
            { "webHostUrl", this.WebHostUrl },
            { "url", this.Url }
        });
    }
}