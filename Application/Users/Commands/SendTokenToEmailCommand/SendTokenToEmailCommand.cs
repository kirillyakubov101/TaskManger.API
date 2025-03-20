using MediatR;

namespace Application.Users.Commands.SendTokenToEmailCommand;

public class SendTokenToEmailCommand : IRequest<bool>
{
    public string Email { get; set; }
}
