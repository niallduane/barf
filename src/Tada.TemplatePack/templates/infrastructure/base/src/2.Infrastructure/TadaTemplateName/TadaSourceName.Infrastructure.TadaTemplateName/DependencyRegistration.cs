using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TadaSourceName.Infrastructure.TadaTemplateName;

public static class DependencyRegistration
{
    public static void ConfigureTadaTemplateName(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<ITadaTemplateNameContext, TadaTemplateNameContext>();
    }
}
