using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartelmen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationWorkerContactDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkerId",
                table: "ContactDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_WorkerId",
                table: "ContactDetails",
                column: "WorkerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Workers_WorkerId",
                table: "ContactDetails",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Workers_WorkerId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_WorkerId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "ContactDetails");
        }
    }
}
