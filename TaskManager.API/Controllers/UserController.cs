using Application.Users.Commands.CreateNewUserCommand;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagmentAPI.Controllers
{

    [ApiController]
    [Route("api/identity/")]
    public class UserController(IMediator mediator) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserCommand createNewUserCommand)
        {
           await mediator.Send(createNewUserCommand);
           return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> AvailableEmail([FromQuery] IsEmailAvailableQuery isEmailAvailableQuery)
        {
            var result = await mediator.Send(isEmailAvailableQuery);

            if(result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new { Message = "Email is already in use." }); 
            }
        }
    }
}
