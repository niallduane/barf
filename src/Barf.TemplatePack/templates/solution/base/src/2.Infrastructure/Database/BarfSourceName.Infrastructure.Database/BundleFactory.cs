using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BarfSourceName.Infrastructure.Database;

public class BundleFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    /// <summary>
    /// This is required to use ef bundle.
    /// </summary>
    /// <remarks>
    /// Using the Api project gives an error as the startup project to generate the bundle generates the following error - `Cannot find DatabaseContext`
    /// </remarks>
    /// <param name="args"></param>
    /// <returns></returns>
    public DatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddEnvironmentVariables()
            .AddUserSecrets("barfsourcename-local-settings")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.Configure(configuration);

        return new DatabaseContext(optionsBuilder.Options);
    }
}
