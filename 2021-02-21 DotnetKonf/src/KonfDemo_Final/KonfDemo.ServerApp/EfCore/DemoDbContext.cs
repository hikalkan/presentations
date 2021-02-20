using KonfDemo.ServerApp.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KonfDemo.ServerApp.EfCore
{
    public class DemoDbContext : AbpDbContext<DemoDbContext>
    {
        public DbSet<LikeRecord> LikeRecords { get; set; }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LikeRecord>(b =>
            {
                b.ToTable("LikeRecords");
                b.ConfigureByConvention();
            });
        }
    }
}
