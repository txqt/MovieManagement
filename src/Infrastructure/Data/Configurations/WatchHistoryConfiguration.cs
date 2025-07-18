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
public class WatchHistoryConfiguration : IEntityTypeConfiguration<WatchHistory>
{
    public void Configure(EntityTypeBuilder<WatchHistory> builder)
    {
        builder.ToTable("WatchHistories");
        builder.HasKey(wh => wh.Id);
        builder.Property(wh => wh.DeviceType).HasMaxLength(100);
        builder.Property(wh => wh.UserAgent).HasMaxLength(500);
        builder.Property(wh => wh.IpAddress).HasMaxLength(50);
        builder.Property(wh => wh.AudioType).HasMaxLength(50);
        builder.Property(wh => wh.SubtitleLanguage).HasMaxLength(50);
        builder.Property(wh => wh.Quality).HasMaxLength(50);
        builder.HasOne<ApplicationUser>().WithMany(u => u.WatchHistories).HasForeignKey(wh => wh.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(wh => wh.Movie).WithMany(m => m.WatchHistories).HasForeignKey(wh => wh.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(wh => wh.Episode).WithMany(e => e.WatchHistories).HasForeignKey(wh => wh.EpisodeId).OnDelete(DeleteBehavior.Cascade);
    }
}
