
using Domain.Entities.User;
using Domain.Repositories;
using Infrastructure.Persistance;
using Infrastructure.Repos;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("TasksDb");
        services.AddDbContext<TaskManagmentDbContext>(options => options.UseNpgsql(connectionString).EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<MainUser>()
            .AddEntityFrameworkStores<TaskManagmentDbContext>();

        services.AddScoped<ITaskRepository, UserTaskRepository>();
        services.AddScoped<IMainUserRepository,MainUserRepository>();   
        services.AddScoped<IRepoSeeder,RepoSeeder>();

    }
}