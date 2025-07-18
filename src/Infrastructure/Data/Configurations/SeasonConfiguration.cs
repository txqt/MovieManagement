using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.ToTable("Seasons");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Status).HasMaxLength(50);
        builder.Property(s => s.AiringSeason).HasMaxLength(50);
        builder.Property(s => s.IsActive).HasDefaultValue(true);
        builder.HasOne(s => s.Movie).WithMany(m => m.Seasons).HasForeignKey(s => s.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(s => s.Episodes).WithOne(e => e.Season).HasForeignKey(e => e.SeasonId).OnDelete(DeleteBehavior.Cascade);
    }
}
