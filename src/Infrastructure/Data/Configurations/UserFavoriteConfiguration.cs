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
public class UserFavoriteConfiguration : IEntityTypeConfiguration<UserFavorite>
{
    public void Configure(EntityTypeBuilder<UserFavorite> builder)
    {
        builder.ToTable("UserFavorites");
        builder.HasKey(uf => uf.Id);
        builder.Property(uf => uf.Order).HasDefaultValue(0);
        builder.HasOne<ApplicationUser>().WithMany(u => u.UserFavorites).HasForeignKey(uf => uf.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(uf => uf.Movie).WithMany(m => m.UserFavorites).HasForeignKey(uf => uf.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(uf => uf.Watchlist).WithMany(wl => wl.UserFavorites).HasForeignKey(uf => uf.WatchlistId).OnDelete(DeleteBehavior.SetNull);
    }
}
