using CleanApiTemplate.Middlewares;
using Microsoft.OpenApi.Models;

namespace CleanApiTemplate.Extensions;

public static class WebApplicationBuilderExtenstion
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAuthentication();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                        },
                        new List<string>()
                    }
                });

        });

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
    }
}
