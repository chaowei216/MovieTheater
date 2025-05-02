using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    ActorName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActorImage = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActorDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sex = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    CityName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    MovieName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    RoleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    TheaterName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theaters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    ActorId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    CharacterName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordSalt = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "utf8mb4_general_ci"),
                    IsBlocked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    TheaterId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    RoomNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    Token = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "utf8mb4_general_ci"),
                    ExpiresAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Showtimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    MovieId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    RoomId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    ShowtimeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AvailableSeat = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showtimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Showtimes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    ShowtimeId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    SeatNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Showtimes_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "Showtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    TicketId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "UUID()", collation: "utf8mb4_general_ci"),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentMethod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "ActorDescription", "ActorImage", "ActorName", "CreatedAt", "DateOfBirth", "Sex", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("e1a6b116-4c62-4e52-9604-1ac13e1e6787"), "Known for action and sci-fi roles.", "keanu_reeves.jpg", "Keanu Reeves", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5955), new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5956) },
                    { new Guid("e8ef376c-49ad-4e9e-bf74-0bb29776c349"), "Known for strong action roles.", "carrie_anne_moss.jpg", "Carrie-Anne Moss", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5962), new DateTime(1967, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5962) },
                    { new Guid("fd34be32-e1be-4245-aed9-846ae6e4c915"), "Acclaimed for emotional performances.", "kate_winslet.jpg", "Kate Winslet", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5960), new DateTime(1975, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5960) },
                    { new Guid("ffc26079-0671-4d1b-8ef6-dfa1a6e2e0c6"), "Versatile actor in drama and thriller.", "leonardo_dicaprio.jpg", "Leonardo DiCaprio", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5958), new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5958) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("bd194da6-7d52-4b75-b2e7-adcf17b26e44"), "Hồ Chí Minh", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5848), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5849) },
                    { new Guid("f5e624c6-bb43-467d-b7b3-cf644f4761f0"), "Hà Nội", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5847), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5847) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "EndDate", "IsPublic", "MovieName", "ReleaseDate", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("40e8b951-ee7b-4cf5-acdc-368987d7af47"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5922), "A hacker discovers a mysterious reality.", 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5922) },
                    { new Guid("90837c03-9cac-48fd-8cd9-cc58be9a773f"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5927), "A love story aboard a doomed ship.", 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Titanic", new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5927) },
                    { new Guid("b56f7815-3a0e-4c3a-8a01-cb3a83096b0b"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5925), "A thief enters dreams to steal secrets.", 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5925) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0f7b52ba-1255-4a2a-bcbd-e9bc8bfc1515"), new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9342), "Customer", new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9342) },
                    { new Guid("26a9bc0d-dc2b-4c2a-8c4e-5dd000aeab0b"), new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9339), "Staff Manager", new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9339) },
                    { new Guid("817175b8-73a4-439d-be60-c66f403fbea0"), new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9333), "Admin", new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9335) },
                    { new Guid("a035064c-6c42-4836-b0b3-6df0d783ae19"), new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9340), "Staff", new DateTime(2025, 5, 2, 5, 32, 7, 277, DateTimeKind.Utc).AddTicks(9341) }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "CharacterName", "CreatedAt", "Id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("e1a6b116-4c62-4e52-9604-1ac13e1e6787"), new Guid("40e8b951-ee7b-4cf5-acdc-368987d7af47"), "Neo", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5985), new Guid("c7c08bf1-a99a-4585-8472-531b44571f33"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5985) },
                    { new Guid("e8ef376c-49ad-4e9e-bf74-0bb29776c349"), new Guid("40e8b951-ee7b-4cf5-acdc-368987d7af47"), "Trinity", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5987), new Guid("a639b8ef-960b-43a1-9d9b-b3754688f5ae"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5987) },
                    { new Guid("fd34be32-e1be-4245-aed9-846ae6e4c915"), new Guid("90837c03-9cac-48fd-8cd9-cc58be9a773f"), "Rose DeWitt Bukater", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5994), new Guid("a9a7374c-4d51-4306-8d27-85d958b501bd"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5994) },
                    { new Guid("ffc26079-0671-4d1b-8ef6-dfa1a6e2e0c6"), new Guid("90837c03-9cac-48fd-8cd9-cc58be9a773f"), "Jack Dawson", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5991), new Guid("c5af74dd-10af-4916-8e4f-9c7119dff75c"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5991) },
                    { new Guid("ffc26079-0671-4d1b-8ef6-dfa1a6e2e0c6"), new Guid("b56f7815-3a0e-4c3a-8a01-cb3a83096b0b"), "Dom Cobb", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5989), new Guid("79d89eab-149b-4de3-a017-25d844cb00f5"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5989) }
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "CityId", "CreatedAt", "Location", "TheaterName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2cc7df46-ddaf-42d1-a2ca-de72d2630650"), new Guid("bd194da6-7d52-4b75-b2e7-adcf17b26e44"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5885), "Số 20, Phố Lý Tự Trọng, Hồ Chí Minh", "BHD Star Cineplex", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5886) },
                    { new Guid("3ffd2193-c4c4-40db-8195-1e91b8a90b7a"), new Guid("bd194da6-7d52-4b75-b2e7-adcf17b26e44"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5883), "Số 10, Phố Nguyễn Huệ, Hồ Chí Minh", "CGV Hồ Chí Minh", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5883) },
                    { new Guid("7d0e4f1c-a23f-40ac-a7e4-b48e7fdb05ba"), new Guid("f5e624c6-bb43-467d-b7b3-cf644f4761f0"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5881), "Số 2, Phố Trần Duy Hưng, Hà Nội", "Lotte Cinema Hà Nội", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5881) },
                    { new Guid("efe6fdcb-285c-4e54-b3dc-15f13ec3a393"), new Guid("f5e624c6-bb43-467d-b7b3-cf644f4761f0"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5878), "Số 1, Phố Ngô Quyền, Hà Nội", "CGV Hà Nội", new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5878) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsBlocked", "PasswordHash", "PasswordSalt", "Phone", "RoleId", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("9dfe6fd3-fcb4-4403-a94d-07161fe9721d"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5810), "staff@example.com", false, "YRvSkuRIf7lSOvUnK2plb+PI/P1GYlMMxv3wvDdNvWE=", "iIRfptVj1+HGdQVQhlZ22Q==", "3333333333", new Guid("a035064c-6c42-4836-b0b3-6df0d783ae19"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5810), "staff" },
                    { new Guid("beac5b1a-415c-4ee2-ab2b-b0ebfc761742"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5803), "admin@example.com", false, "dGKFpHEqxwmRmxf1eiyukmoVAmkQ2yv0iqYtTy8Wm98=", "xgTwBzajWrPs7d/yWyVAVQ==", "1111111111", new Guid("817175b8-73a4-439d-be60-c66f403fbea0"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5804), "admin" },
                    { new Guid("c8155e42-0761-4ca3-9d79-4fadd52fb3a2"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5807), "manager@example.com", false, "dq1tU9BM0nTL+i8tyx48Ek2sDdUSBW0m6VbhU8f+iWY=", "rKeq+ZfhoOf1NLmQLzaQ2w==", "2222222222", new Guid("26a9bc0d-dc2b-4c2a-8c4e-5dd000aeab0b"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5808), "staffmanager" },
                    { new Guid("e915fe56-c8eb-4e94-a61b-abd7080b4a54"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5813), "customer@example.com", false, "QsigimfYAOPyn66FbKTvX+NMZkclQLoaGzGJ/S3L7Xo=", "pnaoPao0xacbWax0WJd54Q==", "4444444444", new Guid("0f7b52ba-1255-4a2a-bcbd-e9bc8bfc1515"), new DateTime(2025, 5, 2, 5, 32, 7, 285, DateTimeKind.Utc).AddTicks(5813), "customer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TheaterId",
                table: "Rooms",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_RoomId",
                table: "Showtimes",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Theaters_CityId",
                table: "Theaters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowtimeId",
                table: "Tickets",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketId",
                table: "Transactions",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Showtimes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Theaters");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
