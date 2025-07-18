using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class MovieCharacterConfiguration : IEntityTypeConfiguration<MovieCharacter>
{
    public void Configure(EntityTypeBuilder<MovieCharacter> builder)
    {
        builder.ToTable("MovieCharacters");
        builder.HasKey(mc => mc.Id);
        builder.HasOne(mc => mc.Movie).WithMany(m => m.MovieCharacters).HasForeignKey(mc => mc.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(mc => mc.Character).WithMany(c => c.MovieCharacters).HasForeignKey(mc => mc.CharacterId).OnDelete(DeleteBehavior.Cascade);
    }
}

