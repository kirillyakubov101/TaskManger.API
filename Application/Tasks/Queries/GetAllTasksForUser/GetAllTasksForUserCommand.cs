using Application.Tasks.Dtos;
using MediatR;
using SharedModels;

namespace Application.Tasks.Queries.GetAllTasksForUser;

public class GetAllTasksForUserCommand : IRequest<IEnumerable<UserTaskDto>>
{

}
