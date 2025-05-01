using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {

            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });


            builder.Property(ma => ma.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)")
                .UseCollation("utf8mb4_general_ci")
                .HasDefaultValueSql("UUID()");


            builder.Property(ma => ma.CharacterName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.ActorId)
     .HasColumnType("char(36)")
     .HasDefaultValueSql("UUID()")
     .UseCollation("utf8mb4_general_ci");
            builder.Property(t => t.MovieId)
     .HasColumnType("char(36)")
     .HasDefaultValueSql("UUID()")
     .UseCollation("utf8mb4_general_ci");

            builder.Property(ma => ma.CreatedAt)
                .IsRequired();



            builder.Property(ma => ma.UpdatedAt)
                .IsRequired(false);
        }
    }
}