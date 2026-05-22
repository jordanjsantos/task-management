using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Api.Persistence
{
    public class TaskDbContext(DbContextOptions<TaskDbContext> options) : DbContext(options)
    {
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
