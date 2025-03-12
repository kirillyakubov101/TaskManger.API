using MediatR;

namespace Application.Tasks.Commands.DeleteTaskById;

public class DeleteTaskByIdCommand : IRequest<bool>
{
    public int Id { get; set; }
}
