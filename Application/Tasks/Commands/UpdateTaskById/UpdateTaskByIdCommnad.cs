using MediatR;
using SharedModels;

namespace Application.Tasks.Commands.UpdateTaskById;

public class UpdateTaskByIdCommnad : IRequest<bool>
{
    public int Id { get; set; }
    public UserTaskEditDto UserTaskEditDto { get; set; }

}
    