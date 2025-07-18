using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using MovieManagementSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscriptions");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Currency).HasMaxLength(10);
        builder.Property(s => s.Status).HasMaxLength(50);
        builder.Property(s => s.IsAutoRenew).HasDefaultValue(true);
        builder.HasOne<ApplicationUser>().WithMany(u => u.Subscriptions).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.SubscriptionPlan).WithMany(sp => sp.Subscriptions).HasForeignKey(s => s.SubscriptionPlanId).OnDelete(DeleteBehavior.Cascade);
    }
}
