using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class CharacterVoiceActorConfiguration : IEntityTypeConfiguration<CharacterVoiceActor>
{
    public void Configure(EntityTypeBuilder<CharacterVoiceActor> builder)
    {
        builder.ToTable("CharacterVoiceActors");
        builder.HasKey(cva => cva.Id);
        builder.Property(cva => cva.Language).IsRequired().HasMaxLength(50);
        builder.HasOne(cva => cva.Character).WithMany(c => c.CharacterVoiceActors).HasForeignKey(cva => cva.CharacterId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(cva => cva.Actor).WithMany(a => a.CharacterVoiceActors).HasForeignKey(cva => cva.ActorId).OnDelete(DeleteBehavior.Cascade);
    }
}
