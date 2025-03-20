using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedModels;
using System.Security.Claims;

namespace Application.Users.Queries.GetCurrentUserInfoQuery;

public class GetCurrentUserInfoQueryHandler(UserManager<MainUser> userManager) : IRequestHandler<GetCurrentUserInfoQuery, UserInfoDto>
{
    public async Task<UserInfoDto> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = request.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("Invalid Token");
        }

        var user = await userManager.FindByIdAsync(userId);

        if(user == null)
        {
            throw new Exception("Invalid user");
        }

        return new UserInfoDto
        {
            UserNickname = user.NickName!
        };
    }
}
