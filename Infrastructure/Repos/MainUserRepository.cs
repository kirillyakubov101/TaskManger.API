using Domain.Entities.User;
using Domain.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos
{
    internal class MainUserRepository(TaskManagmentDbContext taskManagmentDbContext) : IMainUserRepository
    {
        public async Task<MainUser?> GetUserByIdAsync(string id)
        {
           return await taskManagmentDbContext.Users
            .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == id); 
        }
    }
}
