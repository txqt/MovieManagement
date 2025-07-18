using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        builder.ToTable("SubscriptionPlans");
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Name).IsRequired().HasMaxLength(100);
        builder.Property(sp => sp.Currency).HasMaxLength(10);
        builder.Property(sp => sp.CanDownload).HasDefaultValue(false);
        builder.Property(sp => sp.CanWatch4K).HasDefaultValue(false);
        builder.Property(sp => sp.HasAds).HasDefaultValue(true);
        builder.Property(sp => sp.CanAccessAdultContent).HasDefaultValue(false);
        builder.Property(sp => sp.CanAccessSimulcast).HasDefaultValue(false);
        builder.HasMany(sp => sp.Subscriptions).WithOne(s => s.SubscriptionPlan).HasForeignKey(s => s.SubscriptionPlanId).OnDelete(DeleteBehavior.Cascade);
    }
}
