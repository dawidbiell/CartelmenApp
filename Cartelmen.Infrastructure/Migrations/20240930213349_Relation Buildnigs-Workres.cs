using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartelmen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationBuildnigsWorkres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingWorker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingWorker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingWorker_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingWorker_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingWorker_BuildingId",
                table: "BuildingWorker",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingWorker_WorkerId",
                table: "BuildingWorker",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingWorker");
        }
    }
}
