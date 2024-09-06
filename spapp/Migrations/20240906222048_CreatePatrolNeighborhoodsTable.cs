using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spapp.Migrations
{
    /// <inheritdoc />
    public partial class CreatePatrolNeighborhoodsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatrolNeighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatrolId = table.Column<int>(type: "int", nullable: false),
                    NeighbordhoodId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrolNeighborhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrolNeighborhoods_Neighborhoods_NeighbordhoodId",
                        column: x => x.NeighbordhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatrolNeighborhoods_Patrols_PatrolId",
                        column: x => x.PatrolId,
                        principalTable: "Patrols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatrolNeighborhoods_NeighbordhoodId",
                table: "PatrolNeighborhoods",
                column: "NeighbordhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrolNeighborhoods_PatrolId",
                table: "PatrolNeighborhoods",
                column: "PatrolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatrolNeighborhoods");
        }
    }
}
