using Domain.Entities.Task;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class TaskManagmentDbContext : IdentityDbContext<MainUser>
    {
        public TaskManagmentDbContext(DbContextOptions<TaskManagmentDbContext> options) : base(options)
        {
        }
        internal DbSet<UserTask> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            modelBuilder.Entity<UserTask>()
                  .HasOne(t => t.MainUser) // Each Task has one User
                  .WithMany(u => u.Tasks)  // Each User has many Tasks
                  .HasForeignKey(t => t.MainUserId)
                  .OnDelete(DeleteBehavior.Cascade); // Delete tasks if user is deleted
        }

  
    }
}
 