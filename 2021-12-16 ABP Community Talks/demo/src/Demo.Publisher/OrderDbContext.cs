using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Demo.Publisher
{
    public class OrderDbContext : AbpDbContext<OrderDbContext>,
        IHasEventInbox, IHasEventOutbox
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
        public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(b =>
            {
                b.ToTable("Orders");
                b.ConfigureByConvention();
            });

            modelBuilder.ConfigureEventInbox();
            modelBuilder.ConfigureEventOutbox();
        }
    }
}
