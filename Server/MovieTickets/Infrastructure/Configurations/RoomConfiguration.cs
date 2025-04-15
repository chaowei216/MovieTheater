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

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)").UseCollation("utf8mb4_general_ci")
                .HasDefaultValueSql("UUID()");

            builder.Property(r => r.TheaterId)
                .IsRequired();

            builder.Property(r => r.RoomNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Capacity)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.Property(r => r.UpdatedAt)
                .IsRequired(false);

            builder.HasMany(r => r.Showtimes)
                .WithOne(s => s.Room)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Theater)
                .WithMany(t => t.Rooms)
                .HasForeignKey(r => r.TheaterId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.TheaterId)
          .HasColumnType("char(36)")
          .HasDefaultValueSql("UUID()")
          .UseCollation("utf8mb4_general_ci");
        }
    }
}
