using Microsoft.EntityFrameworkCore;

namespace TaskManagementApi.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        { }

        // Define DbSet for the Task model
        public DbSet<TaskItem> Tasks { get; set; }
    }
}