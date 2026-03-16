using Microsoft.EntityFrameworkCore;

namespace Test.Subscriber.Infraestructure.Database
{
    public class SubscriberDbContext : DbContext
    {
        public SubscriberDbContext(DbContextOptions<SubscriberDbContext> options)
            : base(options)
        {
        }
        public DbSet<Core.Entitites.Subscriber> Subscribers { get; set; }

        public DbSet<Core.Entitites.SubscriptionPlan> SubscriptionPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubscriberDbContext).Assembly);
        }
    }
}
