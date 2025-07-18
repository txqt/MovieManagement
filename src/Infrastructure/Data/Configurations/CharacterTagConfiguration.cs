using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class CharacterTagConfiguration : IEntityTypeConfiguration<CharacterTag>
{
    public void Configure(EntityTypeBuilder<CharacterTag> builder)
    {
        builder.ToTable("CharacterTags");
        builder.HasKey(ct => ct.Id);
        builder.HasOne(ct => ct.Character).WithMany(c => c.CharacterTags).HasForeignKey(ct => ct.CharacterId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(ct => ct.Tag).WithMany(t => t.CharacterTags).HasForeignKey(ct => ct.TagId).OnDelete(DeleteBehavior.Cascade);
    }
}
