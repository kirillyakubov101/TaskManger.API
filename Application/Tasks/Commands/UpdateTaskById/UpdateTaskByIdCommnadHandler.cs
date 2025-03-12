using Application.Users;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Commands.UpdateTaskById;

public class UpdateTaskByIdCommnadHandler(ITaskRepository taskRepository, IUserService userService) : IRequestHandler<UpdateTaskByIdCommnad, bool>
{
    public async Task<bool> Handle(UpdateTaskByIdCommnad request, CancellationToken cancellationToken)
    {
        var userId = userService.GetCurrentUserId();
        if (userId == null) { throw new NotFoundException("userId is null"); }

        var task = await taskRepository.GetTaskById(request.Id, userId);

        if(task == null) { throw new NotFoundException("task is null"); }

        task.DueDate = request.UserTaskEditDto.DueDate;
        task.Status = request.UserTaskEditDto.Status;
        task.Priority = request.UserTaskEditDto.Priority;
        task.Description = request.UserTaskEditDto.Description;
        task.Title = request.UserTaskEditDto.Title;

        await taskRepository.SaveChnages();

        return true;
    }
}
