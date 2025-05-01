using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
           
            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)")
                .UseCollation("utf8mb4_general_ci")
                .HasDefaultValueSql("UUID()");

           
            builder.Property(a => a.ActorName)
                .IsRequired()
                .HasMaxLength(100);

     
            builder.Property(a => a.ActorImage)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(a => a.ActorDescription)
                .IsRequired(false);

            builder.Property(a => a.Sex)
                .IsRequired(false);


            builder.Property(a => a.DateOfBirth)
                .IsRequired(false);


            builder.Property(a => a.CreatedAt)
                .IsRequired();
              


            builder.Property(a => a.UpdatedAt)
                .IsRequired(false);


            builder.HasKey(a => a.Id);


            builder.HasMany(a => a.MovieActors)
                .WithOne(ma => ma.Actor)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}