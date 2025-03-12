using Application.Users;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Commands.DeleteTaskById
{
    public class DeleteTaskByIdCommandHandler(ITaskRepository taskRepository,IUserService userService) : IRequestHandler<DeleteTaskByIdCommand, bool>
    {
        public async Task<bool> Handle(DeleteTaskByIdCommand request, CancellationToken cancellationToken)
        {
            var userId = userService.GetCurrentUserId();
            if (userId == null) { throw new NotFoundException("userId is null"); }


            var status =  await taskRepository.DeleteTask(request.Id, userId);
            if (status == false)
            {
                throw new NotFoundException($"task with id {request.Id} was no found");
            }

            return status;
        }
    }
}
