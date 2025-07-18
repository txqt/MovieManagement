using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using MovieManagementSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class UserGenrePreferenceConfiguration : IEntityTypeConfiguration<UserGenrePreference>
{
    public void Configure(EntityTypeBuilder<UserGenrePreference> builder)
    {
        builder.ToTable("UserGenrePreferences");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Score).IsRequired();
        builder.HasOne<ApplicationUser>().WithMany(u => u.UserGenrePreferences).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.Genre).WithMany(g => g.UserGenrePreferences).HasForeignKey(p => p.GenreId).OnDelete(DeleteBehavior.Cascade);
    }
}
