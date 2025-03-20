using MediatR;
using System.Security.Claims;

namespace Application.Users.Queries.GetCurrentUserInfoQuery;

public class GetCurrentUserInfoQuery : IRequest
{
    public GetCurrentUserInfoQuery(ClaimsPrincipal user)
    {
        User = user;
    }

    public string NickName = string.Empty;
    public ClaimsPrincipal User { get; }

  

   
}
