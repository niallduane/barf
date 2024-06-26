using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

using TadaSourceName.Presentation.Api.Attributes;

namespace TadaSourceName.Presentation.Api.Startup;

public static class SwaggerRegistration
{
    public static void RegisterSwagger(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.UseAllOfToExtendReferenceSchemas(); // Allows $ref enums to be nullable
            options.SupportNonNullableReferenceTypes();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TadaSourceName API V1",
                Version = "v1",
                Description = ""
            });

            options.OperationFilter<RequestPatchOperationFilter>();

            // options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            // {
            //     Description = @"JWT Authorization header using the Bearer scheme.
            //           Enter 'Bearer' [space] and then your token in the text input below.
            //           Example: 'Bearer 12345abcdef'",
            //     Name = HeaderNames.Authorization,
            //     In = ParameterLocation.Header,
            //     Type = SecuritySchemeType.ApiKey,
            //     Scheme = "Bearer"
            // });

            // options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            // {
            //     {
            //         new OpenApiSecurityScheme
            //         {
            //             Reference = new OpenApiReference
            //             {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer"
            //             },
            //             Scheme = "oauth2",
            //             Name = "Bearer",
            //             In = ParameterLocation.Header,
            //         },
            //         new List<string>()
            //     },
            // });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.EnableAnnotations();
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            options.DescribeAllParametersInCamelCase();
        });
    }
}