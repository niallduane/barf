using Microsoft.Extensions.DependencyInjection;

namespace BarfSourceName.Infrastructure.BarfTemplateName;

public static class DependencyRegistration
{
    public static void ConfigureBarfTemplateName(this IServiceCollection services)
    {
        services.AddTransient<IBarfTemplateNameContext, BarfTemplateNameContext>();
    }

}
