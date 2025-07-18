using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieManagementSystem.Infrastructure.Data.Configurations;
public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.ToTable("MovieActors");
        builder.HasKey(ma => ma.Id);
        builder.HasOne(ma => ma.Movie).WithMany(m => m.MovieActors).HasForeignKey(ma => ma.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(ma => ma.Actor).WithMany(a => a.MovieActors).HasForeignKey(ma => ma.ActorId).OnDelete(DeleteBehavior.Cascade);
    }
}
