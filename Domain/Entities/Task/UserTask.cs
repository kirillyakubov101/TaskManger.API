
using Domain.Entities.User;
using SharedModels;

namespace Domain.Entities.Task;

public class UserTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public UserTaskStatus Status { get; set; } = UserTaskStatus.Pending; // Enum: Pending, InProgress, Completed
    public UserTaskPriority Priority { get; set; } = UserTaskPriority.Normal; // Enum: Low, Normal, High
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }

    // Foreign Key (Use string because IdentityUser has a string ID)
    public string MainUserId { get; set; }
    public MainUser MainUser { get; set; }
}

