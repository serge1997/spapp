using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spapp.Migrations
{
    /// <inheritdoc />
    public partial class CreatePatrolNeighborhoodSectorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatrolNeighborhoodSectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatrolId = table.Column<int>(type: "int", nullable: false),
                    NeighbordhoodSectorId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrolNeighborhoodSectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrolNeighborhoodSectors_NeighborhoodSectors_NeighbordhoodSectorId",
                        column: x => x.NeighbordhoodSectorId,
                        principalTable: "NeighborhoodSectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrolNeighborhoodSectors_Patrols_PatrolId",
                        column: x => x.PatrolId,
                        principalTable: "Patrols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatrolNeighborhoodSectors_NeighbordhoodSectorId",
                table: "PatrolNeighborhoodSectors",
                column: "NeighbordhoodSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrolNeighborhoodSectors_PatrolId",
                table: "PatrolNeighborhoodSectors",
                column: "PatrolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatrolNeighborhoodSectors");
        }
    }
}
