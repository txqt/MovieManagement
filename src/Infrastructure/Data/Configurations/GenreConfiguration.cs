using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
        builder.Property(g => g.IsAdultGenre).HasDefaultValue(false);
        builder.Property(g => g.Type).HasDefaultValue("General");
        builder.HasMany(g => g.MovieGenres).WithOne(mg => mg.Genre).HasForeignKey(mg => mg.GenreId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(g => g.UserGenrePreferences).WithOne(p => p.Genre).HasForeignKey(p => p.GenreId).OnDelete(DeleteBehavior.Cascade);
    }
}
