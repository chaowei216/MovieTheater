using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{

    public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> builder)
        {
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)").UseCollation("utf8mb4_general_ci")
                .HasDefaultValueSql("UUID()");

            builder.Property(t => t.TheaterName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Location)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.CityId)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired(false);

            builder.HasMany(t => t.Rooms)
                .WithOne(r => r.Theater)
                .HasForeignKey(r => r.TheaterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.City)
                .WithMany(c => c.Theaters)
                .HasForeignKey(t => t.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.CityId)
          .HasColumnType("char(36)")
          .HasDefaultValueSql("UUID()")
          .UseCollation("utf8mb4_general_ci");
        }
    }
}
