using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed
{
    public interface IRepoSeeder
    {
        Task Seed();
    }
    public class RepoSeeder(TaskManagmentDbContext dbContext) : IRepoSeeder
    {
        public async Task Seed()
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            await dbContext.Database.CanConnectAsync();
        }
    }
}
