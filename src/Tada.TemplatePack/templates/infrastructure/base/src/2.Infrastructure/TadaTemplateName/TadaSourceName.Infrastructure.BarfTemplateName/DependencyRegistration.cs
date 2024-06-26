using Microsoft.Extensions.DependencyInjection;

namespace TadaSourceName.Infrastructure.TadaTemplateName;

public static class DependencyRegistration
{
    public static void ConfigureTadaTemplateName(this IServiceCollection services)
    {
        services.AddTransient<ITadaTemplateNameContext, TadaTemplateNameContext>();
    }

}
