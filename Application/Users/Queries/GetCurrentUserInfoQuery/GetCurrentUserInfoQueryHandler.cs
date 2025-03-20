using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Application.Users.Queries.GetCurrentUserInfoQuery;

public class GetCurrentUserInfoQueryHandler(UserManager<MainUser> userManager) : IRequestHandler<GetCurrentUserInfoQuery>
{
    public async Task Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = request.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("Invalid Token");
        }
            
        var user = await userManager.FindByIdAsync(userId);

         
    }
}
