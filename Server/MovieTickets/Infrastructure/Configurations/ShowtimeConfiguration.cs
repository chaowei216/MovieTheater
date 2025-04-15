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

    public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
    {
        public void Configure(EntityTypeBuilder<Showtime> builder)
        {
            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)").UseCollation("utf8mb4_general_ci")
                .HasDefaultValueSql("UUID()");

            builder.Property(s => s.MovieId)
                .IsRequired();

            builder.Property(s => s.RoomId)
                .IsRequired();

            builder.Property(s => s.ShowtimeDate)
                .IsRequired();

            builder.Property(s => s.AvailableSeat)
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.Property(s => s.UpdatedAt)
                .IsRequired(false);

            builder.HasMany(s => s.Tickets)
                .WithOne(t => t.Showtime)
                .HasForeignKey(t => t.ShowtimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Room)
                .WithMany(r => r.Showtimes)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.MovieId)
          .HasColumnType("char(36)")
          .HasDefaultValueSql("UUID()")
          .UseCollation("utf8mb4_general_ci");
            builder.Property(t => t.RoomId)
          .HasColumnType("char(36)")
          .HasDefaultValueSql("UUID()")
          .UseCollation("utf8mb4_general_ci");
        }
    }
}
