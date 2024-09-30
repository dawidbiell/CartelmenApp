using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartelmen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationBuildingAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Buildings");
        }
    }
}
