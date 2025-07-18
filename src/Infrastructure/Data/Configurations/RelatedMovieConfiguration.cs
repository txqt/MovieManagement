using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class RelatedMovieConfiguration : IEntityTypeConfiguration<RelatedMovie>
{
    public void Configure(EntityTypeBuilder<RelatedMovie> builder)
    {
        builder.ToTable("RelatedMovies");
        builder.HasKey(rm => rm.Id);
        builder.Property(rm => rm.RelationType).IsRequired().HasMaxLength(50);
        builder.HasOne(rm => rm.SourceMovie).WithMany(m => m.RelatedMoviesAsSource).HasForeignKey(rm => rm.SourceMovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(rm => rm.RelatedMovieNavigation).WithMany(m => m.RelatedMoviesAsRelated).HasForeignKey(rm => rm.RelatedMovieId).OnDelete(DeleteBehavior.Cascade);
    }
}
