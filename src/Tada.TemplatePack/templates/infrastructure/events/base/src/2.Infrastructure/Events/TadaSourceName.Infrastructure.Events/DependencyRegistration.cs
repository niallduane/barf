using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TadaSourceName.Infrastructure.Event;

public static class DependencyRegistration
{
    public static void ConfigureEvents(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IEventContext, EventContext>();
    }
}