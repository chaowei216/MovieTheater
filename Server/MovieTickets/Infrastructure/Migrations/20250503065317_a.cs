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
                    MovieImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    { new Guid("5c56da82-871d-4993-b918-30238918232c"), "Versatile actor in drama and thriller.", "leonardo_dicaprio.jpg", "Leonardo DiCaprio", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8393), new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8393) },
                    { new Guid("71e9e85b-e367-4038-84d6-91cfa8997488"), "Known for strong action roles.", "carrie_anne_moss.jpg", "Carrie-Anne Moss", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8397), new DateTime(1967, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8397) },
                    { new Guid("f58bd65c-3508-46c3-9eb8-d55ac431db1e"), "Acclaimed for emotional performances.", "kate_winslet.jpg", "Kate Winslet", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8395), new DateTime(1975, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8395) },
                    { new Guid("fd2fd92d-f031-4413-9185-70b639486717"), "Known for action and sci-fi roles.", "keanu_reeves.jpg", "Keanu Reeves", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8391), new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8391) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("50a7f8e6-5f75-4a46-8cbb-27c3d3860f7f"), "Hà Nội", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8277), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8278) },
                    { new Guid("bc167d53-29dc-41ae-b8aa-b8c20c1d0ca7"), "Hồ Chí Minh", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8303), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8304) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "EndDate", "IsPublic", "MovieImage", "MovieName", "ReleaseDate", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6b216128-bfe7-4e66-987f-2106c724c60b"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8368), "A love story aboard a doomed ship.", 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Titanic", new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8368) },
                    { new Guid("c05797db-c6c7-4501-b86b-3279a6101c8b"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8363), "A hacker discovers a mysterious reality.", 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8363) },
                    { new Guid("d7dc21e5-f25c-4dfd-a681-ce576bd4cf0c"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8366), "A thief enters dreams to steal secrets.", 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8366) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("56c6e118-fd38-4feb-be1e-167e2e483682"), new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9650), "Staff", new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9650) },
                    { new Guid("5d6358d1-a354-4b82-991c-6c035995d376"), new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9648), "Staff Manager", new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9649) },
                    { new Guid("77c08f1c-9206-42d4-ab5d-722c7942701d"), new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9652), "Customer", new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9652) },
                    { new Guid("b5b7860b-c60b-40c9-83ad-634d83638cd7"), new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9638), "Admin", new DateTime(2025, 5, 3, 6, 53, 15, 848, DateTimeKind.Utc).AddTicks(9639) }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "CharacterName", "CreatedAt", "Id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5c56da82-871d-4993-b918-30238918232c"), new Guid("6b216128-bfe7-4e66-987f-2106c724c60b"), "Jack Dawson", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8422), new Guid("780bd05d-244f-4343-a7a7-4b768064a626"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8422) },
                    { new Guid("f58bd65c-3508-46c3-9eb8-d55ac431db1e"), new Guid("6b216128-bfe7-4e66-987f-2106c724c60b"), "Rose DeWitt Bukater", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8423), new Guid("41048d7b-7bc4-4c28-b0cf-3bc04b64e5b3"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8424) },
                    { new Guid("71e9e85b-e367-4038-84d6-91cfa8997488"), new Guid("c05797db-c6c7-4501-b86b-3279a6101c8b"), "Trinity", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8418), new Guid("393d176e-4f52-4d05-a1f8-b5b42d919df8"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8418) },
                    { new Guid("fd2fd92d-f031-4413-9185-70b639486717"), new Guid("c05797db-c6c7-4501-b86b-3279a6101c8b"), "Neo", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8414), new Guid("1f977863-a473-430b-a5d0-7be79e1faf29"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8414) },
                    { new Guid("5c56da82-871d-4993-b918-30238918232c"), new Guid("d7dc21e5-f25c-4dfd-a681-ce576bd4cf0c"), "Dom Cobb", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8420), new Guid("94e4c52b-7d44-4fa9-af8e-b5d82efbeb5e"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8420) }
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "CityId", "CreatedAt", "Location", "TheaterName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02b7a969-43a2-4625-965f-f74da2645878"), new Guid("bc167d53-29dc-41ae-b8aa-b8c20c1d0ca7"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8332), "Số 10, Phố Nguyễn Huệ, Hồ Chí Minh", "CGV Hồ Chí Minh", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8332) },
                    { new Guid("23b84abc-99f6-48c4-b77b-728b5b7cac28"), new Guid("50a7f8e6-5f75-4a46-8cbb-27c3d3860f7f"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8327), "Số 1, Phố Ngô Quyền, Hà Nội", "CGV Hà Nội", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8328) },
                    { new Guid("a69dc5c0-a91a-41c4-8366-e2a91669f2df"), new Guid("50a7f8e6-5f75-4a46-8cbb-27c3d3860f7f"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8330), "Số 2, Phố Trần Duy Hưng, Hà Nội", "Lotte Cinema Hà Nội", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8330) },
                    { new Guid("f75aa1fe-c36e-42c5-b99c-af89e5728e24"), new Guid("bc167d53-29dc-41ae-b8aa-b8c20c1d0ca7"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8334), "Số 20, Phố Lý Tự Trọng, Hồ Chí Minh", "BHD Star Cineplex", new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8334) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsBlocked", "PasswordHash", "PasswordSalt", "Phone", "RoleId", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("02530f11-bfbb-411d-89ec-372a4a96810b"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8242), "manager@example.com", false, "S0xyLl7H2ph53W2CrDc/4Uu4IrlcltlVldY4l7TwJZw=", "psJCzS+yvzIRRVd1kCJJrw==", "2222222222", new Guid("5d6358d1-a354-4b82-991c-6c035995d376"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8242), "staffmanager" },
                    { new Guid("73ff0a84-b8dd-4ea8-9637-20a2f89e4805"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8251), "customer@example.com", false, "86UgGt0G6cIcC5ERWWDBLe3vEZdetp6HePHEiKzn6yM=", "vqnU5mqV9vUrQxMG338n/A==", "4444444444", new Guid("77c08f1c-9206-42d4-ab5d-722c7942701d"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8252), "customer" },
                    { new Guid("80f33926-0701-46c4-92c9-73e8989ae924"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8238), "admin@example.com", false, "8EleeVK4645feOy6QMfohV5xfgOyqt0Oc5kHGbJh4hM=", "C16cVVOFWAJ6vtAQ0fHh0g==", "1111111111", new Guid("b5b7860b-c60b-40c9-83ad-634d83638cd7"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8239), "admin" },
                    { new Guid("ee093080-7da4-4c02-8f60-5f0761ae89a2"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8248), "staff@example.com", false, "hINikXQdpCF3wQE8rO7vMh0X4+n6Bjl7Pf25d+T0xMg=", "ZhyCaM4PJUw+3EcG2dXqlw==", "3333333333", new Guid("56c6e118-fd38-4feb-be1e-167e2e483682"), new DateTime(2025, 5, 3, 6, 53, 15, 856, DateTimeKind.Utc).AddTicks(8249), "staff" }
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
