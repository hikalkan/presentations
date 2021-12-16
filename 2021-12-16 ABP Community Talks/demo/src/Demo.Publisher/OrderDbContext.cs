using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Demo.Publisher
{
    public class OrderDbContext : AbpDbContext<OrderDbContext>,
        IHasEventInbox, IHasEventOutbox /* IMPLEMENTING OUTBOX & INBOX FOR THIS DBCONTEXT */
    {
        public DbSet<Order> Orders { get; set; }

        /* TABLES TO STORE OUTGOING AND INCOMING EVENTS */
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

            /* CONFIGURE THE Inbox/Outbox RELATED TABLES */
            modelBuilder.ConfigureEventInbox();
            modelBuilder.ConfigureEventOutbox();
        }
    }
}
