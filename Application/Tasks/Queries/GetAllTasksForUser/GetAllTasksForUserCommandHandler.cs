using Application.Tasks.Dtos;
using Application.Users;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using SharedModels;

namespace Application.Tasks.Queries.GetAllTasksForUser
{
    public class GetAllTasksForUserCommandHandler(IMapper mapper, IMainUserRepository mainUserRepository, IUserService userService) : IRequestHandler<GetAllTasksForUserCommand, IEnumerable<UserTaskDto>>
    {
        public async Task<IEnumerable<UserTaskDto>> Handle(GetAllTasksForUserCommand request, CancellationToken cancellationToken)
        {
            var userId = userService.GetCurrentUserId();
            var user = await mainUserRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("user is null");    
            }

            var tasksDto = mapper.Map<IEnumerable<UserTaskDto>>(user.Tasks);
            return tasksDto;
        }
    }
}
