using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class SubtitleConfiguration : IEntityTypeConfiguration<Subtitle>
{
    public void Configure(EntityTypeBuilder<Subtitle> builder)
    {
        builder.ToTable("Subtitles");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Language).IsRequired().HasMaxLength(50);
        builder.Property(s => s.LanguageCode).IsRequired().HasMaxLength(10);
        builder.Property(s => s.FilePath).IsRequired().HasMaxLength(500);
        builder.Property(s => s.Format).HasMaxLength(10);
        builder.Property(s => s.IsDefault).HasDefaultValue(false);
        builder.Property(s => s.IsForced).HasDefaultValue(false);
        builder.Property(s => s.SubtitleType).HasMaxLength(50);
        builder.Property(s => s.TranslatorGroup).HasMaxLength(100);
        builder.Property(s => s.IsActive).HasDefaultValue(true);
        builder.HasOne(s => s.Movie).WithMany(m => m.Subtitles).HasForeignKey(s => s.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Episode).WithMany(e => e.Subtitles).HasForeignKey(s => s.EpisodeId).OnDelete(DeleteBehavior.Cascade);
    }
}
