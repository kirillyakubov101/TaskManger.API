using MediatR;

namespace Application.Users.Queries.IsEmailAvailableQuery;

public class IsEmailAvailableQuery : IRequest<bool>
{
    public string Email { get; set; }
}
