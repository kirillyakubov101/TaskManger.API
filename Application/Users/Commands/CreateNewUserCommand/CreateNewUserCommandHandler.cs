using AutoMapper;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Commands.CreateNewUserCommand;

public class CreateNewUserCommandHandler(UserManager<MainUser> userManager, IMapper mapper) : IRequestHandler<CreateNewUserCommand>
{
    public async Task Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
    {
        
       var user = mapper.Map<MainUser>(request);
       var result = await userManager.CreateAsync(user,request.Password);

        if (!result.Succeeded)
        {
            // Handle errors (throw exception or return error result)
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
        }
    }
}
