using MediatR;
using SharedModels;

namespace Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserTaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
