using Domain.Entities.Task;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User;

public class MainUser : IdentityUser
{
    public string? NickName { get; set; }
    public string? PasswordToken {  get; set; }
    public DateTime TokenExpireDate { get; set; }

    // A user can have multiple tasks
    public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();

}
