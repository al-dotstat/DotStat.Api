using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotStat.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "api");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "developers",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameRu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "districts",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "complexes",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameRu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_complexes_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "api",
                        principalTable: "districts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileExpiredDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "api",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                schema: "api",
                columns: table => new
                {
                    RefreshTokenId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Device = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiredDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => new { x.RefreshTokenId, x.UserId });
                    table.ForeignKey(
                        name: "FK_refresh_tokens_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "api",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_claims",
                schema: "api",
                columns: table => new
                {
                    UserClaimId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claims", x => new { x.UserClaimId, x.UserId });
                    table.ForeignKey(
                        name: "FK_user_claims_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "api",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "api",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.UserRoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_user_roles_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "api",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "buildings",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buildings_complexes_ComplexId",
                        column: x => x.ComplexId,
                        principalSchema: "api",
                        principalTable: "complexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "complex_developers",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complex_developers", x => new { x.Id, x.ComplexId });
                    table.ForeignKey(
                        name: "FK_complex_developers_complexes_ComplexId",
                        column: x => x.ComplexId,
                        principalSchema: "api",
                        principalTable: "complexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_complex_developers_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "api",
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parsings",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    AreFlatsParsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AreParkingsParsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AreStoragesParsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AreCommercialsParsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parsings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parsings_complexes_ComplexId",
                        column: x => x.ComplexId,
                        principalSchema: "api",
                        principalTable: "complexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    IncludeFlats = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IncludeParkings = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IncludeStorages = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IncludeCommercials = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => new { x.Id, x.OrderId });
                    table.ForeignKey(
                        name: "FK_order_items_complexes_ComplexId",
                        column: x => x.ComplexId,
                        principalSchema: "api",
                        principalTable: "complexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "api",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "commercials",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeveloperUnique = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commercials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commercials_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "api",
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commercials_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "api",
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "flats",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEuro = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DeveloperUnique = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flats_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "api",
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flats_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "api",
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parkings",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeveloperUnique = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parkings_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "api",
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parkings_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "api",
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "storages",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeveloperUnique = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_storages_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "api",
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storages_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "api",
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "commercial_declaration",
                schema: "api",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "int", nullable: false),
                    CommercialId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    Entrance = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unique = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commercial_declaration", x => new { x.DeclarationId, x.CommercialId });
                    table.ForeignKey(
                        name: "FK_commercial_declaration_commercials_CommercialId",
                        column: x => x.CommercialId,
                        principalSchema: "api",
                        principalTable: "commercials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "commercial_parsing_infos",
                schema: "api",
                columns: table => new
                {
                    CommercialParsingInfoId = table.Column<int>(type: "int", nullable: false),
                    CommercialId = table.Column<int>(type: "int", nullable: false),
                    ParseId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: true),
                    Building = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commercial_parsing_infos", x => new { x.CommercialParsingInfoId, x.CommercialId });
                    table.ForeignKey(
                        name: "FK_commercial_parsing_infos_commercials_CommercialId",
                        column: x => x.CommercialId,
                        principalSchema: "api",
                        principalTable: "commercials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commercial_parsing_infos_parsings_ParseId",
                        column: x => x.ParseId,
                        principalSchema: "api",
                        principalTable: "parsings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "flat_declaration",
                schema: "api",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "int", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Roominess = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    LivingArea = table.Column<double>(type: "double", nullable: false),
                    CeilingHeight = table.Column<double>(type: "double", nullable: false),
                    Entrance = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unique = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flat_declaration", x => new { x.DeclarationId, x.FlatId });
                    table.ForeignKey(
                        name: "FK_flat_declaration_flats_FlatId",
                        column: x => x.FlatId,
                        principalSchema: "api",
                        principalTable: "flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "flat_parsing_infos",
                schema: "api",
                columns: table => new
                {
                    FlatParsingInfoId = table.Column<int>(type: "int", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    ParseId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Roominess = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: true),
                    LivingArea = table.Column<double>(type: "double", nullable: true),
                    Building = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flat_parsing_infos", x => new { x.FlatParsingInfoId, x.FlatId });
                    table.ForeignKey(
                        name: "FK_flat_parsing_infos_flats_FlatId",
                        column: x => x.FlatId,
                        principalSchema: "api",
                        principalTable: "flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flat_parsing_infos_parsings_ParseId",
                        column: x => x.ParseId,
                        principalSchema: "api",
                        principalTable: "parsings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parking_declaration",
                schema: "api",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "int", nullable: false),
                    ParkingId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    Entrance = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unique = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parking_declaration", x => new { x.DeclarationId, x.ParkingId });
                    table.ForeignKey(
                        name: "FK_parking_declaration_parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalSchema: "api",
                        principalTable: "parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parking_parsing_infos",
                schema: "api",
                columns: table => new
                {
                    ParkingParsingInfoId = table.Column<int>(type: "int", nullable: false),
                    ParkingId = table.Column<int>(type: "int", nullable: false),
                    ParseId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: true),
                    Building = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parking_parsing_infos", x => new { x.ParkingParsingInfoId, x.ParkingId });
                    table.ForeignKey(
                        name: "FK_parking_parsing_infos_parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalSchema: "api",
                        principalTable: "parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parking_parsing_infos_parsings_ParseId",
                        column: x => x.ParseId,
                        principalSchema: "api",
                        principalTable: "parsings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "storage_declaration",
                schema: "api",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    Entrance = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unique = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage_declaration", x => new { x.DeclarationId, x.StorageId });
                    table.ForeignKey(
                        name: "FK_storage_declaration_storages_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "api",
                        principalTable: "storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "storage_parsing_infos",
                schema: "api",
                columns: table => new
                {
                    StorageParsingInfoId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ParseId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: true),
                    Building = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalJsonInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage_parsing_infos", x => new { x.StorageParsingInfoId, x.StorageId });
                    table.ForeignKey(
                        name: "FK_storage_parsing_infos_parsings_ParseId",
                        column: x => x.ParseId,
                        principalSchema: "api",
                        principalTable: "parsings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storage_parsing_infos_storages_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "api",
                        principalTable: "storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_ComplexId",
                schema: "api",
                table: "buildings",
                column: "ComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_commercial_declaration_CommercialId",
                schema: "api",
                table: "commercial_declaration",
                column: "CommercialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_commercial_parsing_infos_CommercialId",
                schema: "api",
                table: "commercial_parsing_infos",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_commercial_parsing_infos_ParseId",
                schema: "api",
                table: "commercial_parsing_infos",
                column: "ParseId");

            migrationBuilder.CreateIndex(
                name: "IX_commercials_BuildingId",
                schema: "api",
                table: "commercials",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_commercials_DeveloperId",
                schema: "api",
                table: "commercials",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_complex_developers_ComplexId",
                schema: "api",
                table: "complex_developers",
                column: "ComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_complex_developers_DeveloperId",
                schema: "api",
                table: "complex_developers",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_complexes_DistrictId",
                schema: "api",
                table: "complexes",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_flat_declaration_FlatId",
                schema: "api",
                table: "flat_declaration",
                column: "FlatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flat_parsing_infos_FlatId",
                schema: "api",
                table: "flat_parsing_infos",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_flat_parsing_infos_ParseId",
                schema: "api",
                table: "flat_parsing_infos",
                column: "ParseId");

            migrationBuilder.CreateIndex(
                name: "IX_flats_BuildingId",
                schema: "api",
                table: "flats",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_flats_DeveloperId",
                schema: "api",
                table: "flats",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_ComplexId",
                schema: "api",
                table: "order_items",
                column: "ComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_OrderId",
                schema: "api",
                table: "order_items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                schema: "api",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_parking_declaration_ParkingId",
                schema: "api",
                table: "parking_declaration",
                column: "ParkingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_parking_parsing_infos_ParkingId",
                schema: "api",
                table: "parking_parsing_infos",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_parking_parsing_infos_ParseId",
                schema: "api",
                table: "parking_parsing_infos",
                column: "ParseId");

            migrationBuilder.CreateIndex(
                name: "IX_parkings_BuildingId",
                schema: "api",
                table: "parkings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_parkings_DeveloperId",
                schema: "api",
                table: "parkings",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_parsings_ComplexId",
                schema: "api",
                table: "parsings",
                column: "ComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_UserId",
                schema: "api",
                table: "refresh_tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_storage_declaration_StorageId",
                schema: "api",
                table: "storage_declaration",
                column: "StorageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_storage_parsing_infos_ParseId",
                schema: "api",
                table: "storage_parsing_infos",
                column: "ParseId");

            migrationBuilder.CreateIndex(
                name: "IX_storage_parsing_infos_StorageId",
                schema: "api",
                table: "storage_parsing_infos",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_storages_BuildingId",
                schema: "api",
                table: "storages",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_storages_DeveloperId",
                schema: "api",
                table: "storages",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_UserId",
                schema: "api",
                table: "user_claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_UserId",
                schema: "api",
                table: "user_roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                schema: "api",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commercial_declaration",
                schema: "api");

            migrationBuilder.DropTable(
                name: "commercial_parsing_infos",
                schema: "api");

            migrationBuilder.DropTable(
                name: "complex_developers",
                schema: "api");

            migrationBuilder.DropTable(
                name: "flat_declaration",
                schema: "api");

            migrationBuilder.DropTable(
                name: "flat_parsing_infos",
                schema: "api");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "api");

            migrationBuilder.DropTable(
                name: "parking_declaration",
                schema: "api");

            migrationBuilder.DropTable(
                name: "parking_parsing_infos",
                schema: "api");

            migrationBuilder.DropTable(
                name: "refresh_tokens",
                schema: "api");

            migrationBuilder.DropTable(
                name: "storage_declaration",
                schema: "api");

            migrationBuilder.DropTable(
                name: "storage_parsing_infos",
                schema: "api");

            migrationBuilder.DropTable(
                name: "user_claims",
                schema: "api");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "api");

            migrationBuilder.DropTable(
                name: "commercials",
                schema: "api");

            migrationBuilder.DropTable(
                name: "flats",
                schema: "api");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "api");

            migrationBuilder.DropTable(
                name: "parkings",
                schema: "api");

            migrationBuilder.DropTable(
                name: "parsings",
                schema: "api");

            migrationBuilder.DropTable(
                name: "storages",
                schema: "api");

            migrationBuilder.DropTable(
                name: "users",
                schema: "api");

            migrationBuilder.DropTable(
                name: "buildings",
                schema: "api");

            migrationBuilder.DropTable(
                name: "developers",
                schema: "api");

            migrationBuilder.DropTable(
                name: "complexes",
                schema: "api");

            migrationBuilder.DropTable(
                name: "districts",
                schema: "api");
        }
    }
}
