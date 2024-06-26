using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TadaSourceName.Infrastructure.Database.Repositories;
public static class DependencyRegistration
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration config)
    {
        // <!-- tada injection token -->
    }
}