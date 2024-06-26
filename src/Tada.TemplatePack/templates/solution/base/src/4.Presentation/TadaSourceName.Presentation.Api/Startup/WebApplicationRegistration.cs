using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Versioning;
using TadaSourceName.Presentation.Api.Middleware;

namespace TadaSourceName.Presentation.Api.Startup;

public static class WebApplicationRegistration
{
    public static void RegisterMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ResponseTimer>();
    }
}