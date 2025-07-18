using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class CollectionMovieConfiguration : IEntityTypeConfiguration<CollectionMovie>
{
    public void Configure(EntityTypeBuilder<CollectionMovie> builder)
    {
        builder.ToTable("CollectionMovies");
        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Order).HasDefaultValue(0);
        builder.HasOne(cm => cm.Collection).WithMany(c => c.CollectionMovies).HasForeignKey(cm => cm.CollectionId).OnDelete(DeleteBehavior.Cascade);
    }
}
