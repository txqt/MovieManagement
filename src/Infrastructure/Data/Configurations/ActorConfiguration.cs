using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("Actors");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Property(a => a.JapaneseName).HasMaxLength(100);
        builder.Property(a => a.RomajiName).HasMaxLength(100);
        builder.Property(a => a.ProfileImageUrl).HasMaxLength(500);
        builder.Property(a => a.IsActive).HasDefaultValue(true);
        builder.Property(a => a.Type).HasDefaultValue("Actor");
        builder.HasMany(a => a.MovieActors).WithOne(ma => ma.Actor).HasForeignKey(ma => ma.ActorId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(a => a.CharacterVoiceActors).WithOne(cva => cva.Actor).HasForeignKey(cva => cva.ActorId).OnDelete(DeleteBehavior.Cascade);
    }
}
