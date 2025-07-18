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
public class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
        builder.ToTable("Watchlists");
        builder.HasKey(wl => wl.Id);
        builder.Property(wl => wl.Name).IsRequired().HasMaxLength(100);
        builder.Property(wl => wl.Description).HasMaxLength(500);
        builder.Property(wl => wl.IsPublic).HasDefaultValue(false);
        builder.Property(wl => wl.IsDefault).HasDefaultValue(false);
        builder.HasOne<ApplicationUser>().WithMany(u => u.Watchlists).HasForeignKey(wl => wl.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(wl => wl.UserFavorites).WithOne(uf => uf.Watchlist).HasForeignKey(uf => uf.WatchlistId).OnDelete(DeleteBehavior.SetNull);
    }
}
