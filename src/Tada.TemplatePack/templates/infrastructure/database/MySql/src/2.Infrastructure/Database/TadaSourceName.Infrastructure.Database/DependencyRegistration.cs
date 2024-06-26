using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TadaSourceName.Infrastructure.Database;

public static class DependencyRegistration
{
    public static DbContextOptionsBuilder Configure(this DbContextOptionsBuilder options, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Database")!;
        var version = config.GetConnectionString("DatabaseVersion")!;
        options.UseMySql(connectionString, ServerVersion.Parse(version), option => SetOptions(option));
#if DEBUG
            options.EnableSensitiveDataLogging();
#endif
        return options;
    }

    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DatabaseContext>((serviceProvider, options) => options.Configure(config));
    }

    private static void SetOptions(MySqlDbContextOptionsBuilder options)
    {
        options.UseNetTopologySuite();
        options.UseMicrosoftJson(MySqlCommonJsonChangeTrackingOptions.FullHierarchyOptimizedFast);
    }
}
