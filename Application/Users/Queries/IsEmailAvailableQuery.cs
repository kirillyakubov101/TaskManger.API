using MediatR;

namespace Application.Users.Queries;

public class IsEmailAvailableQuery : IRequest<bool>
{
    public string Email { get; set; }
}
