using Application.Users;
using AutoMapper;
using Domain.Entities.Task;
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper, IUserService userService) : IRequestHandler<CreateTaskCommand>
{
    public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var userTask = mapper.Map<UserTask>(request);
        userTask.MainUserId = userService.GetCurrentUserId();
        await taskRepository.CreateTask(userTask);
    }
}
