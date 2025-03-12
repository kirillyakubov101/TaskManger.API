using Domain.Entities.Task;
using Domain.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

internal class UserTaskRepository(TaskManagmentDbContext dbContext) : ITaskRepository
{
    public async Task CreateTask(UserTask task)
    {
        await dbContext.Tasks.AddAsync(task);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteTask(int UserTaskId, string UserId)
    {
        var taskToDelete = await dbContext.Tasks
        .FirstOrDefaultAsync(us => us.MainUserId == UserId && us.Id == UserTaskId);

        if (taskToDelete != null)
        {
            dbContext.Tasks.Remove(taskToDelete); 
            await dbContext.SaveChangesAsync();    
            return true;  
        }
        else
        {
            return false;
        }
    }

    public async Task<UserTask?> GetTaskById(int userTaskId, string UserId)
    {
        return await dbContext.Tasks.FirstOrDefaultAsync(us => us.Id == userTaskId && us.MainUserId == UserId);
    }

    public Task SaveChnages()
    {
        return dbContext.SaveChangesAsync();
    }
}
