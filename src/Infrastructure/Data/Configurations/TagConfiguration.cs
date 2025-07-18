using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Type).HasDefaultValue("General");
        builder.Property(t => t.IsActive).HasDefaultValue(true);
        builder.HasMany(t => t.MovieTags).WithOne(mt => mt.Tag).HasForeignKey(mt => mt.TagId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(t => t.CharacterTags).WithOne(ct => ct.Tag).HasForeignKey(ct => ct.TagId).OnDelete(DeleteBehavior.Cascade);
    }
}
