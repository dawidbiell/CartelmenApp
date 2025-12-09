using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartelmen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TimeTruckerId_remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TimeTracker");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracker_IsSubmitted",
                table: "TimeTracker",
                column: "IsSubmitted",
                filter: "IsSubmitted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeTracker_IsSubmitted",
                table: "TimeTracker");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TimeTracker",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
