using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartelmen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTimeTrackerWhereWhoIdtoSpotPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracks_SpotPerson_WhereWhoId",
                table: "TimeTracks");

            migrationBuilder.RenameColumn(
                name: "WhereWhoId",
                table: "TimeTracks",
                newName: "SpotPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTracks_WhereWhoId",
                table: "TimeTracks",
                newName: "IX_TimeTracks_SpotPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracks_SpotPerson_SpotPersonId",
                table: "TimeTracks",
                column: "SpotPersonId",
                principalTable: "SpotPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracks_SpotPerson_SpotPersonId",
                table: "TimeTracks");

            migrationBuilder.RenameColumn(
                name: "SpotPersonId",
                table: "TimeTracks",
                newName: "WhereWhoId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTracks_SpotPersonId",
                table: "TimeTracks",
                newName: "IX_TimeTracks_WhereWhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracks_SpotPerson_WhereWhoId",
                table: "TimeTracks",
                column: "WhereWhoId",
                principalTable: "SpotPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
