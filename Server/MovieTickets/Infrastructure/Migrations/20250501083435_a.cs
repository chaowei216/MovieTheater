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
                    { new Guid("20fc1583-66a4-4192-a092-35727200538b"), "Known for strong action roles.", "carrie_anne_moss.jpg", "Carrie-Anne Moss", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1585), new DateTime(1967, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1585) },
                    { new Guid("43d0c1ba-ab3b-40ab-b231-7fc3bf4c476c"), "Versatile actor in drama and thriller.", "leonardo_dicaprio.jpg", "Leonardo DiCaprio", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1581), new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1581) },
                    { new Guid("d866ff45-12e9-4e71-9af3-19c11e7f8aae"), "Acclaimed for emotional performances.", "kate_winslet.jpg", "Kate Winslet", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1583), new DateTime(1975, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1584) },
                    { new Guid("fd793ab2-4e49-48d5-85c6-68b9c12971de"), "Known for action and sci-fi roles.", "keanu_reeves.jpg", "Keanu Reeves", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1579), new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1579) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0026cc79-bbc8-42ac-a90a-a3dd3e0a727b"), "Hồ Chí Minh", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1431), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1432) },
                    { new Guid("6ddd6364-bd03-415f-bbe7-554a428c36a6"), "Hà Nội", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1430), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1430) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "EndDate", "IsPublic", "MovieName", "ReleaseDate", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("764fb557-05ce-4bca-9d04-999f336e6b98"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1532), "A hacker discovers a mysterious reality.", 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1532) },
                    { new Guid("7f1fa5b9-47b2-429d-90e8-d0a0cd1a6a3a"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1534), "A thief enters dreams to steal secrets.", 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1535) },
                    { new Guid("a23e28a1-4aab-40b4-b160-f60f27f71051"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1536), "A love story aboard a doomed ship.", 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Titanic", new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1537) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("215c6bbf-bdf0-400d-96c3-6aad720bc906"), new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3056), "Admin", new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3059) },
                    { new Guid("77a2089b-4eaa-499d-861e-4f05b6179669"), new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3066), "Staff", new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3067) },
                    { new Guid("9cf2f0f7-caf8-4483-b3b6-0d8f5fdd9a65"), new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3064), "Staff Manager", new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3065) },
                    { new Guid("be1e013d-af34-40de-aff9-13b9df5bb8b3"), new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3072), "Customer", new DateTime(2025, 5, 1, 8, 34, 35, 223, DateTimeKind.Utc).AddTicks(3072) }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "CharacterName", "CreatedAt", "Id", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("20fc1583-66a4-4192-a092-35727200538b"), new Guid("764fb557-05ce-4bca-9d04-999f336e6b98"), "Trinity", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1611), new Guid("a77c1cb4-8cbe-4881-8e82-2c288cc98b4a"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1611) },
                    { new Guid("fd793ab2-4e49-48d5-85c6-68b9c12971de"), new Guid("764fb557-05ce-4bca-9d04-999f336e6b98"), "Neo", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1608), new Guid("3f1c8d1d-41ad-483e-a1a1-8d3c07fd0833"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1609) },
                    { new Guid("43d0c1ba-ab3b-40ab-b231-7fc3bf4c476c"), new Guid("7f1fa5b9-47b2-429d-90e8-d0a0cd1a6a3a"), "Dom Cobb", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1613), new Guid("7162da6f-9692-4145-a94b-2fc09f656672"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1613) },
                    { new Guid("43d0c1ba-ab3b-40ab-b231-7fc3bf4c476c"), new Guid("a23e28a1-4aab-40b4-b160-f60f27f71051"), "Jack Dawson", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1617), new Guid("b44a066b-2c5a-44ae-bc7c-3c9e8906c801"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1617) },
                    { new Guid("d866ff45-12e9-4e71-9af3-19c11e7f8aae"), new Guid("a23e28a1-4aab-40b4-b160-f60f27f71051"), "Rose DeWitt Bukater", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1619), new Guid("ad50b5d4-a580-4686-baf3-29733d3d4da2"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1619) }
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "CityId", "CreatedAt", "Location", "TheaterName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1fbea266-85f7-44f9-8ac1-2d46a4a63dcc"), new Guid("0026cc79-bbc8-42ac-a90a-a3dd3e0a727b"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1483), "Số 20, Phố Lý Tự Trọng, Hồ Chí Minh", "BHD Star Cineplex", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1484) },
                    { new Guid("4b7a6550-d220-459b-9764-002550f35674"), new Guid("6ddd6364-bd03-415f-bbe7-554a428c36a6"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1476), "Số 1, Phố Ngô Quyền, Hà Nội", "CGV Hà Nội", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1476) },
                    { new Guid("7022649f-3afa-4407-aea5-160f8bc5e4f5"), new Guid("6ddd6364-bd03-415f-bbe7-554a428c36a6"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1479), "Số 2, Phố Trần Duy Hưng, Hà Nội", "Lotte Cinema Hà Nội", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1480) },
                    { new Guid("cb92edde-ff81-40ae-8b5b-7dc4b4944b2f"), new Guid("0026cc79-bbc8-42ac-a90a-a3dd3e0a727b"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1481), "Số 10, Phố Nguyễn Huệ, Hồ Chí Minh", "CGV Hồ Chí Minh", new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1482) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "PasswordSalt", "Phone", "RoleId", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("2321cd66-ec34-4891-adf8-9494a6c75a0e"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1317), "manager@example.com", "ARHQMBtPvTbPbroA0WR1LKfE5hc553SMLbBqA1TVGMs=", "vnp6kJhAlJD5CATHgxpWVQ==", "2222222222", new Guid("9cf2f0f7-caf8-4483-b3b6-0d8f5fdd9a65"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1317), "staffmanager" },
                    { new Guid("83f7c844-8ef4-4003-bbfc-561b89ecdc82"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1197), "admin@example.com", "Es/BQ4SBRiRgvdiIK6u8hPn/gYtSRrmW5uG7pykWPFU=", "cHmG0ecSaCP2zkWsEb+bkg==", "1111111111", new Guid("215c6bbf-bdf0-400d-96c3-6aad720bc906"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1200), "admin" },
                    { new Guid("dbca29e1-7f25-4529-99cc-d2cea53a516b"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1320), "staff@example.com", "81p9dir0zB1b2kwOKitS0U8IXxqCqugg7NEkoIJJd+E=", "UaydkzO3be7DGZ7pWt0gDA==", "3333333333", new Guid("77a2089b-4eaa-499d-861e-4f05b6179669"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1321), "staff" },
                    { new Guid("fceed40c-56f9-4827-9740-53805f920e26"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1324), "customer@example.com", "PyFPxFcDjERhjtUAalz2BjK4uTdgGb/Dspc6HKHDTf0=", "lI02mur/w8o1Kgp2gmqV2A==", "4444444444", new Guid("be1e013d-af34-40de-aff9-13b9df5bb8b3"), new DateTime(2025, 5, 1, 8, 34, 35, 232, DateTimeKind.Utc).AddTicks(1328), "customer" }
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
