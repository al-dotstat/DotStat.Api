using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotStat.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogoFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                schema: "api",
                table: "developers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                schema: "api",
                table: "complexes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                schema: "api",
                table: "developers");

            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                schema: "api",
                table: "complexes");
        }
    }
}
