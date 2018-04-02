using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Application
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            return new MyDbContext(
                new DbContextOptionsBuilder<MyDbContext>()
                    .UseSqlServer(MultiTenantDbContextServiceCollectionExtensions.GetDefaultConnectionString())
                    .Options
            );
        }
    }
}