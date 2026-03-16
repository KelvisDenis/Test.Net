using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Subscriber.Core.Entitites;


namespace Test.Subscriber.Infraestructure.Database.Configs
{
    public class SubscriberDbConfig : IEntityTypeConfiguration<Core.Entitites.Subscriber>
    {
        public void Configure(EntityTypeBuilder<Core.Entitites.Subscriber> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.SubscriptionStartDate)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.Status)
                .IsRequired();


            builder.HasOne(x => x.SubscriptionPlan)
                .WithMany(x => x.Subscribers)
                .HasForeignKey(x => x.SubscriptionPlanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
