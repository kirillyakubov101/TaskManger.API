using Application.Users.Commands.CreateNewUserCommand;
using Application.Users.Commands.SendTokenToEmailCommand;
using Application.Users.Queries.IsEmailAvailableQuery;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskManagmentAPI.Controllers
{

    [ApiController]
    [Route("api/identity/")]
    public class UserController(IMediator mediator, UserManager<MainUser> userManager) : Controller
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

        [HttpPost("ResetPasswordSendEmail")]
        public async Task<IActionResult> ResetPasswordSendEmail(SendTokenToEmailCommand sendTokenToEmailCommand)
        {
            var status =  await mediator.Send(sendTokenToEmailCommand);
            if(status)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("Invalid Token");

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            return Ok(new
            {
                Nickname = user.NickName // Assuming this property exists
            });
        }
    }
}
