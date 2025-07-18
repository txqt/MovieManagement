using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> builder)
    {
        builder.ToTable("Collections");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Type).IsRequired().HasMaxLength(50);
        builder.Property(c => c.IsActive).HasDefaultValue(true);
        builder.HasMany(c => c.CollectionMovies).WithOne(cm => cm.Collection).HasForeignKey(cm => cm.CollectionId).OnDelete(DeleteBehavior.Cascade);
    }
}
