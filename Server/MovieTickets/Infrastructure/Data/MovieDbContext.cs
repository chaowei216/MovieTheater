using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);

            // Seed Role
            var roleId = Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = roleId,
                    RoleName = "User",
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed User
            var hasher = new PasswordHasher();
            var (hash, salt) = hasher.HashPassword("password123");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testuser",
                    Email = "testuser@example.com",
                    Phone = "+1234567890",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    RoleId = roleId,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}