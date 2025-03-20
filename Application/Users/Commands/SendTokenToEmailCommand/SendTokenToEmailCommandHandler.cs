using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Application.Users.Commands.SendTokenToEmailCommand;

public class SendTokenToEmailCommandHandler(UserManager<MainUser> _userManager) : IRequestHandler<SendTokenToEmailCommand, bool>
{
    public async Task<bool> Handle(SendTokenToEmailCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByEmailAsync(request.Email);
        if(User == null)
        {
            return false;
        }

        var resetCode = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

        return true;
    }
}
