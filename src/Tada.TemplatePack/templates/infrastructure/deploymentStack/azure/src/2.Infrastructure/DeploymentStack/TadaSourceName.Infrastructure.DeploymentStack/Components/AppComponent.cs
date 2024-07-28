using Pulumi;
using Pulumi.AzureNative.Network;
using Pulumi.AzureNative.Network.Inputs;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;

namespace TadaSourceName.Infrastructure.DeploymentStack.Components;

public class AppComponent : ComponentResource
{
    public Output<string> WebHostUrl { get; private set; }
    public Output<string> Url { get; private set; }

    public AppComponent(string name, ResourceGroup resourceGroup, Input<string> connectionString, ComponentResourceOptions? opts = null)
        : base("custom:resource:AppComponent", name, opts)
    {
        var config = new Pulumi.Config();

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
                        ConnectionString = connectionString,
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
        var cnameRecord = new RecordSet("tadaSourceNameDnsRecord", new RecordSetArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ZoneName = dnsZone.Name,
            RelativeRecordSetName = "www",
            RecordType = "CNAME",
            Ttl = 300,
            CnameRecord = new CnameRecordArgs
            {
                Cname = webApp.DefaultHostName.Apply(hostname => hostname)
            }
        });
        this.WebHostUrl = webApp.DefaultHostName.Apply(hostname => $"https://{hostname}");
        this.Url = Output.Format($"https://{cnameRecord.CnameRecord}.{dnsZone.Name}");

        this.RegisterOutputs(new Dictionary<string, object?>
        {
            { "webHostUrl", this.WebHostUrl },
            { "url", this.Url }
        });
    }
}