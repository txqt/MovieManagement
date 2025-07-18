using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Application.Common.Interfaces;
using MovieManagementSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.FullName).HasMaxLength(100);
        builder.Property(u => u.DisplayName).HasMaxLength(100);
        builder.Property(u => u.Avatar).HasMaxLength(255);
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);
        builder.Property(u => u.Gender).HasMaxLength(20);
        builder.Property(u => u.Country).HasMaxLength(100);
        builder.Property(u => u.PreferredLanguage).HasMaxLength(50);
        builder.Property(u => u.PreferredSubtitleLanguage).HasMaxLength(50);
        builder.Property(u => u.PreferSubtitles).HasDefaultValue(true);
        builder.Property(u => u.PreferDubbed).HasDefaultValue(false);
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.IsPremium).HasDefaultValue(false);
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("now() AT TIME ZONE 'UTC'");
        builder.Property(u => u.UpdatedAt).HasDefaultValueSql("now() AT TIME ZONE 'UTC'");

        builder.HasMany(u => u.Reviews).WithOne().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.Ratings).WithOne().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.WatchHistories).WithOne().HasForeignKey(wh => wh.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.Watchlists).WithOne().HasForeignKey(wl => wl.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.UserFavorites).WithOne().HasForeignKey(uf => uf.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.Subscriptions).WithOne().HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.UserGenrePreferences).WithOne().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
