using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Queries;

public class IsEmailAvailableQueryHandler(UserManager<MainUser> _userManager) : IRequestHandler<IsEmailAvailableQuery, bool>
{
    public async Task<bool> Handle(IsEmailAvailableQuery request, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        return existingUser == null;
    }
}
