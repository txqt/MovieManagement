using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class VideoFileConfiguration : IEntityTypeConfiguration<VideoFile>
{
    public void Configure(EntityTypeBuilder<VideoFile> builder)
    {
        builder.ToTable("VideoFiles");
        builder.HasKey(vf => vf.Id);
        builder.Property(vf => vf.FilePath).IsRequired().HasMaxLength(500);
        builder.Property(vf => vf.Quality).HasMaxLength(50);
        builder.Property(vf => vf.Format).HasMaxLength(10);
        builder.Property(vf => vf.IsActive).HasDefaultValue(true);
        builder.Property(vf => vf.AudioType).HasMaxLength(50);
        builder.Property(vf => vf.AudioLanguage).HasMaxLength(50);
        builder.HasOne(vf => vf.Movie).WithMany(m => m.VideoFiles).HasForeignKey(vf => vf.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(vf => vf.Episode).WithMany(e => e.VideoFiles).HasForeignKey(vf => vf.EpisodeId).OnDelete(DeleteBehavior.Cascade);
    }
}
