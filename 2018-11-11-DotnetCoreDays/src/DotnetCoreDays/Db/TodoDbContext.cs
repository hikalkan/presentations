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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>().HasQueryFilter(e => e.IsDeleted == false);
        }
    }
}
