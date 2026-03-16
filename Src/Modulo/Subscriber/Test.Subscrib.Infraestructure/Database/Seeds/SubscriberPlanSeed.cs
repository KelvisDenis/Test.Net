using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Subscriber.Core.Entitites;
using Test.Subscriber.Core.Enums;

namespace Test.Subscriber.Infrastructure.Database.Seeds;

public class SubscriberPlanSeed : IEntityTypeConfiguration<SubscriptionPlan>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        builder.HasData(
            new SubscriptionPlanSeedData
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Basic",
                MonthlyPrice = 29.90m,
                DaysToExpire = 30,
                Status = PlanManagementEnum.Active,
                CreatedAt = DateTime.UtcNow
            },
            new SubscriptionPlanSeedData
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Premium",
                MonthlyPrice = 59.90m,
                DaysToExpire = 30,
                Status = PlanManagementEnum.Active,
                CreatedAt = DateTime.UtcNow
            },
            new SubscriptionPlanSeedData
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Enterprise",
                MonthlyPrice = 99.90m,
                DaysToExpire = 30,
                Status = PlanManagementEnum.Active,
                CreatedAt = DateTime.UtcNow
            }
        );
    }

    private class SubscriptionPlanSeedData
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal MonthlyPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public PlanManagementEnum Status { get; set; }
        public int DaysToExpire { get; set; }
    }
}