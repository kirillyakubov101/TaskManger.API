using MediatR;

namespace Application.Users.Commands.CreateNewUserCommand
{
    public class CreateNewUserCommand() : IRequest
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
