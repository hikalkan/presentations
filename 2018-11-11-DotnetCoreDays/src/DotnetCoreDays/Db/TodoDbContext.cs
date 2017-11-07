using DotnetCoreDays.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreDays.Db
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {

        }
    }
}
