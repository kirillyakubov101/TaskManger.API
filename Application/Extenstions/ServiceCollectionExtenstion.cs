using Application.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extenstions;

public static class ServiceCollectionExtenstion
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtenstion).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUserService, UserService>();
    }
}
