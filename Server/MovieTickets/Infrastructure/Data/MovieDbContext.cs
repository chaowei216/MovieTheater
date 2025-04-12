using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.HasCharSet("utf8mb4")
                        .UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(c => c.CityId);
                entity.Property(c => c.CityId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(c => c.CityName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(c => c.Theaters)
                      .WithOne(t => t.City)
                      .HasForeignKey(t => t.CityId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);
                entity.Property(r => r.RoleId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(r => r.RoleName).IsRequired().HasMaxLength(50);
                entity.Property(r => r.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(r => r.Users)
                      .WithOne(u => u.Role)
                      .HasForeignKey(u => u.RoleId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Email).HasMaxLength(255);
                entity.Property(u => u.Phone).HasMaxLength(20);
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.PasswordSalt).IsRequired();
                entity.Property(u => u.RoleId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci"); // Cấu hình collation cho khóa ngoại
                entity.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(u => u.Tickets)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.UserId);

                entity.HasMany(u => u.Transactions)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.UserId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.MovieId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(m => m.MovieName).IsRequired().HasMaxLength(255);
                entity.Property(m => m.Description).HasColumnType("TEXT");
                entity.Property(m => m.IsPublic).HasDefaultValue(true);
                entity.Property(m => m.Duration).IsRequired();
                entity.Property(m => m.ReleaseDate).IsRequired();
                entity.Property(m => m.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(m => m.Showtimes)
                      .WithOne(s => s.Movie)
                      .HasForeignKey(s => s.MovieId);
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.HasKey(t => t.TheaterId);
                entity.Property(t => t.TheaterId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.TheaterName).IsRequired().HasMaxLength(255);
                entity.Property(t => t.Location).HasMaxLength(255);
                entity.Property(t => t.CityId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(t => t.Rooms)
                      .WithOne(r => r.Theater)
                      .HasForeignKey(r => r.TheaterId);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(r => r.RoomId);
                entity.Property(r => r.RoomId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(r => r.RoomNumber).IsRequired().HasMaxLength(50);
                entity.Property(r => r.Capacity).IsRequired();
                entity.Property(r => r.TheaterId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(r => r.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(r => r.Showtimes)
                      .WithOne(s => s.Room)
                      .HasForeignKey(s => s.RoomId);
            });

            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.HasKey(s => s.ShowtimeId);
                entity.Property(s => s.ShowtimeId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(s => s.ShowtimeDate).IsRequired();
                entity.Property(s => s.AvailableSeat).IsRequired();
                entity.Property(s => s.MovieId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(s => s.RoomId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(s => s.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasMany(s => s.Tickets)
                      .WithOne(t => t.Showtime)
                      .HasForeignKey(t => t.ShowtimeId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.TicketId);
                entity.Property(t => t.TicketId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.SeatNumber).IsRequired().HasMaxLength(10);
                entity.Property(t => t.Price).IsRequired().HasPrecision(10, 2);
                entity.Property(t => t.PurchaseDate).IsRequired();
                entity.Property(t => t.UserId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.ShowtimeId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.CreateAt).HasDefaultValue(DateTime.UtcNow);

                entity.HasOne(t => t.Transaction)
                      .WithOne(t => t.Ticket)
                      .HasForeignKey<Transaction>(t => t.TicketId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.TransactionId);
                entity.Property(t => t.TransactionId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.TotalAmount).IsRequired().HasPrecision(10, 2);
                entity.Property(t => t.TransactionDate).IsRequired();
                entity.Property(t => t.Status).IsRequired().HasMaxLength(50);
                entity.Property(t => t.PaymentMethod).HasMaxLength(50);
                entity.Property(t => t.UserId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.TicketId)
                      .HasColumnType("char(36)")
                      .UseCollation("utf8mb4_unicode_ci");
                entity.Property(t => t.CreateAt).HasDefaultValue(DateTime.UtcNow);
            });
        }
    }
}