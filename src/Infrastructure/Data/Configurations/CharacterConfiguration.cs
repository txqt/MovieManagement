using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.JapaneseName).HasMaxLength(100);
        builder.Property(c => c.RomajiName).HasMaxLength(100);
        builder.Property(c => c.ImageUrl).HasMaxLength(500);
        builder.Property(c => c.IsActive).HasDefaultValue(true);
        builder.HasMany(c => c.MovieCharacters).WithOne(mc => mc.Character).HasForeignKey(mc => mc.CharacterId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(c => c.CharacterTags).WithOne(ct => ct.Character).HasForeignKey(ct => ct.CharacterId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(c => c.CharacterVoiceActors).WithOne(cva => cva.Character).HasForeignKey(cva => cva.CharacterId).OnDelete(DeleteBehavior.Cascade);
    }
}
