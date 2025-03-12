using Application.Tasks.Commands.CreateTask;
using Application.Tasks.Commands.DeleteTaskById;
using Application.Tasks.Commands.UpdateTaskById;
using Application.Tasks.Queries.GetAllTasksForUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanApiTemplate.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/tasks")]
    public class TasksController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddTask(CreateTaskCommand createTaskCommand)
        {
            await mediator.Send(createTaskCommand);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksForUser()
        {
           var tasks =  await mediator.Send(new GetAllTasksForUserCommand());
           return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskById([FromRoute] int id)
        {
            var command = new DeleteTaskByIdCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTaskById([FromRoute] int id, [FromBody] UpdateTaskByIdCommnad command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }
    }
}
