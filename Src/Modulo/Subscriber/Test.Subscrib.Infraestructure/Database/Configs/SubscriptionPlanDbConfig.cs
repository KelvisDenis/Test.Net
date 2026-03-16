using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Subscriber.Core.Entitites;

namespace Test.Subscriber.Infraestructure.Database.Configs
{
    public class SubscriptionPlanDbConfig : IEntityTypeConfiguration<SubscriptionPlan>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MonthlyPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();


            builder.Property(x => x.UpdatedAt);


            builder.Property(x => x.DaysToExpire)
                .IsRequired();

        }
    }
}
