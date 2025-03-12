
using CleanApiTemplate.Extensions;
using Domain.Entities.User;
using Infrastructure.Extensions;
using Application.Extenstions;
using CleanApiTemplate.Middlewares;
using Infrastructure.Seed;

namespace CleanApiTemplate;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddPresentation();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IRepoSeeder>();
            await seeder.Seed();



            app.UseMiddleware<ErrorHandlingMiddleware>();




            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGroup("api/identity")
           .WithTags("Identity")
           .MapIdentityApi<MainUser>();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        finally
        {
           
        }
        
    }
}


