using Microsoft.EntityFrameworkCore;

namespace MultiTenancyDraft.Application
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }
    }
}
