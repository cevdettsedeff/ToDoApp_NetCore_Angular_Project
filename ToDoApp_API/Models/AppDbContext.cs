using Microsoft.EntityFrameworkCore;

namespace ToDoApp_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Todo>? Todos { get; set; }
    }
}
