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
public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
{
    public void Configure(EntityTypeBuilder<Recommendation> builder)
    {
        builder.ToTable("Recommendations");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Type).IsRequired().HasMaxLength(50);
        builder.Property(r => r.Score).IsRequired();
        builder.Property(r => r.IsActive).HasDefaultValue(true);
        builder.HasOne(r => r.Movie).WithMany().HasForeignKey(r => r.MovieId).OnDelete(DeleteBehavior.Cascade);
    }
}
