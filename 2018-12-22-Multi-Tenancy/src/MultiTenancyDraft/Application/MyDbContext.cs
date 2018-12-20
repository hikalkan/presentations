using System;
using Microsoft.EntityFrameworkCore;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Application
{
    public class MyDbContext : DbContext
    {
        public Guid? CurrentTenantId => TenantInfo.Current?.Id;

        public DbSet<Product> Products { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(b =>
            {
                b.HasQueryFilter(p => p.TenantId == CurrentTenantId);
            });
        }
    }
}
