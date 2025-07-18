using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).IsRequired().HasMaxLength(255);
        builder.Property(m => m.JapaneseTitle).HasMaxLength(255);
        builder.Property(m => m.PosterUrl).HasMaxLength(500);
        builder.Property(m => m.BackdropUrl).HasMaxLength(500);
        builder.Property(m => m.Status).HasDefaultValue("Released");
        builder.Property(m => m.ContentType).HasDefaultValue("Movie");
        builder.Property(m => m.HasSub).HasDefaultValue(true);
        builder.Property(m => m.HasDub).HasDefaultValue(false);
        builder.Property(m => m.Created).HasDefaultValueSql("now() AT TIME ZONE 'UTC'");
        builder.Property(m => m.LastModified).HasDefaultValueSql("now() AT TIME ZONE 'UTC'");

        builder.HasOne(m => m.Category).WithMany(c => c.Movies).HasForeignKey(m => m.CategoryId).OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(m => m.Reviews).WithOne(r => r.Movie).HasForeignKey(r => r.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.Ratings).WithOne(r => r.Movie).HasForeignKey(r => r.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.WatchHistories).WithOne(wh => wh.Movie).HasForeignKey(wh => wh.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.VideoFiles).WithOne(vf => vf.Movie).HasForeignKey(vf => vf.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.Subtitles).WithOne(s => s.Movie).HasForeignKey(s => s.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.Seasons).WithOne(s => s.Movie).HasForeignKey(s => s.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.MovieGenres).WithOne(mg => mg.Movie).HasForeignKey(mg => mg.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.MovieActors).WithOne(ma => ma.Movie).HasForeignKey(ma => ma.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.MovieCharacters).WithOne(mc => mc.Movie).HasForeignKey(mc => mc.MovieId).OnDelete(DeleteBehavior.Cascade);
    }
}
