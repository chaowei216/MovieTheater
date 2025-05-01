using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Pomelo.EntityFrameworkCore.MySql.Update.Internal;

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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IModificationCommandBatchFactory, MySqlModificationCommandBatchFactory>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);

            // Seed Roles
            var adminRoleId = Guid.NewGuid();
            var staffManagerRoleId = Guid.NewGuid();
            var staffRoleId = Guid.NewGuid();
            var customerRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, RoleName = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Role { Id = staffManagerRoleId, RoleName = "Staff Manager", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Role { Id = staffRoleId, RoleName = "Staff", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Role { Id = customerRoleId, RoleName = "Customer", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Seed Users
            var hasher = new PasswordHasher();
            var (adminHash, adminSalt) = hasher.HashPassword("admin123");
            var (staffManagerHash, staffManagerSalt) = hasher.HashPassword("manager123");
            var (staffHash, staffSalt) = hasher.HashPassword("staff123");
            var (customerHash, customerSalt) = hasher.HashPassword("customer123");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Email = "admin@example.com",
                    Phone = "1111111111",
                    PasswordHash = adminHash,
                    PasswordSalt = adminSalt,
                    RoleId = adminRoleId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "staffmanager",
                    Email = "manager@example.com",
                    Phone = "2222222222",
                    PasswordHash = staffManagerHash,
                    PasswordSalt = staffManagerSalt,
                    RoleId = staffManagerRoleId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "staff",
                    Email = "staff@example.com",
                    Phone = "3333333333",
                    PasswordHash = staffHash,
                    PasswordSalt = staffSalt,
                    RoleId = staffRoleId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "customer",
                    Email = "customer@example.com",
                    Phone = "4444444444",
                    PasswordHash = customerHash,
                    PasswordSalt = customerSalt,
                    RoleId = customerRoleId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

           
            var hanoiCityId = Guid.NewGuid();
            var hoChiMinhCityId = Guid.NewGuid();

            modelBuilder.Entity<City>().HasData(
                new City { Id = hanoiCityId, CityName = "Hà Nội", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new City { Id = hoChiMinhCityId, CityName = "Hồ Chí Minh", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );


            modelBuilder.Entity<Theater>().HasData(
                new Theater
                {
                    Id = Guid.NewGuid(),
                    TheaterName = "CGV Hà Nội",
                    Location = "Số 1, Phố Ngô Quyền, Hà Nội",
                    CityId = hanoiCityId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Theater
                {
                    Id = Guid.NewGuid(),
                    TheaterName = "Lotte Cinema Hà Nội",
                    Location = "Số 2, Phố Trần Duy Hưng, Hà Nội",
                    CityId = hanoiCityId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Theater
                {
                    Id = Guid.NewGuid(),
                    TheaterName = "CGV Hồ Chí Minh",
                    Location = "Số 10, Phố Nguyễn Huệ, Hồ Chí Minh",
                    CityId = hoChiMinhCityId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Theater
                {
                    Id = Guid.NewGuid(),
                    TheaterName = "BHD Star Cineplex",
                    Location = "Số 20, Phố Lý Tự Trọng, Hồ Chí Minh",
                    CityId = hoChiMinhCityId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );


            var movie1Id = Guid.NewGuid();
            var movie2Id = Guid.NewGuid();
            var movie3Id = Guid.NewGuid();

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = movie1Id,
                    MovieName = "The Matrix",
                    Description = "A hacker discovers a mysterious reality.",
                    IsPublic = true,
                    Duration = 136,
                    ReleaseDate = new DateTime(1999, 3, 31),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Movie
                {
                    Id = movie2Id,
                    MovieName = "Inception",
                    Description = "A thief enters dreams to steal secrets.",
                    IsPublic = true,
                    Duration = 148,
                    ReleaseDate = new DateTime(2010, 7, 16),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Movie
                {
                    Id = movie3Id,
                    MovieName = "Titanic",
                    Description = "A love story aboard a doomed ship.",
                    IsPublic = true,
                    Duration = 195,
                    ReleaseDate = new DateTime(1997, 12, 19),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

    
            var actor1Id = Guid.NewGuid();
            var actor2Id = Guid.NewGuid();
            var actor3Id = Guid.NewGuid();
            var actor4Id = Guid.NewGuid();

            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = actor1Id,
                    ActorName = "Keanu Reeves",
                    ActorImage = "keanu_reeves.jpg",
                    ActorDescription = "Known for action and sci-fi roles.",
                    Sex = "Male",
                    DateOfBirth = new DateTime(1964, 9, 2),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Actor
                {
                    Id = actor2Id,
                    ActorName = "Leonardo DiCaprio",
                    ActorImage = "leonardo_dicaprio.jpg",
                    ActorDescription = "Versatile actor in drama and thriller.",
                    Sex = "Male",
                    DateOfBirth = new DateTime(1974, 11, 11),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Actor
                {
                    Id = actor3Id,
                    ActorName = "Kate Winslet",
                    ActorImage = "kate_winslet.jpg",
                    ActorDescription = "Acclaimed for emotional performances.",
                    Sex = "Female",
                    DateOfBirth = new DateTime(1975, 10, 5),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Actor
                {
                    Id = actor4Id,
                    ActorName = "Carrie-Anne Moss",
                    ActorImage = "carrie_anne_moss.jpg",
                    ActorDescription = "Known for strong action roles.",
                    Sex = "Female",
                    DateOfBirth = new DateTime(1967, 8, 21),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

      
            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor
                {
                    Id = Guid.NewGuid(),
                    MovieId = movie1Id,
                    ActorId = actor1Id,
                    CharacterName = "Neo",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new MovieActor
                {
                    Id = Guid.NewGuid(),
                    MovieId = movie1Id,
                    ActorId = actor4Id,
                    CharacterName = "Trinity",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new MovieActor
                {
                    Id = Guid.NewGuid(),
                    MovieId = movie2Id,
                    ActorId = actor2Id,
                    CharacterName = "Dom Cobb",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new MovieActor
                {
                    Id = Guid.NewGuid(),
                    MovieId = movie3Id,
                    ActorId = actor2Id,
                    CharacterName = "Jack Dawson",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new MovieActor
                {
                    Id = Guid.NewGuid(),
                    MovieId = movie3Id,
                    ActorId = actor3Id,
                    CharacterName = "Rose DeWitt Bukater",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
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