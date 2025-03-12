using Domain.Entities.Task;

namespace Domain.Repositories;

public interface ITaskRepository
{
    Task SaveChnages();
    Task CreateTask(UserTask task);
    Task<bool> DeleteTask(int userTaskId, string UserId);
    Task <UserTask?> GetTaskById(int userTaskId,string UserId);
    
}
