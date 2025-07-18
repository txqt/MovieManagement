using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.ToTable("Episodes");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(255);
        builder.Property(e => e.JapaneseTitle).HasMaxLength(255);
        builder.Property(e => e.ThumbnailUrl).HasMaxLength(500);
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsFillerEpisode).HasDefaultValue(false);
        builder.Property(e => e.IsRecapEpisode).HasDefaultValue(false);
        builder.Property(e => e.IsSpecialEpisode).HasDefaultValue(false);
        builder.Property(e => e.EpisodeType).HasMaxLength(50);
        builder.HasOne(e => e.Movie).WithMany(m => m.Episodes).HasForeignKey(e => e.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Season).WithMany(s => s.Episodes).HasForeignKey(e => e.SeasonId).OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(e => e.VideoFiles).WithOne(vf => vf.Episode).HasForeignKey(vf => vf.EpisodeId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Subtitles).WithOne(s => s.Episode).HasForeignKey(s => s.EpisodeId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.WatchHistories).WithOne(wh => wh.Episode).HasForeignKey(wh => wh.EpisodeId).OnDelete(DeleteBehavior.Cascade);
    }
}
