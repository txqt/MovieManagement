using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class MovieTagConfiguration : IEntityTypeConfiguration<MovieTag>
{
    public void Configure(EntityTypeBuilder<MovieTag> builder)
    {
        builder.ToTable("MovieTags");
        builder.HasKey(mt => mt.Id);
        builder.HasOne(mt => mt.Movie).WithMany(m => m.MovieTags).HasForeignKey(mt => mt.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(mt => mt.Tag).WithMany(t => t.MovieTags).HasForeignKey(mt => mt.TagId).OnDelete(DeleteBehavior.Cascade);
    }
}
