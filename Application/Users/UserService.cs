using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Users
{
    public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
    {
        public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return string.IsNullOrEmpty(userId) ? string.Empty : userId;
        }
    }
}
