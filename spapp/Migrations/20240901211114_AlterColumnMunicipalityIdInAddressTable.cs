using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spapp.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnMunicipalityIdInAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MunicipalityId",
                table: "Addresses",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalityId",
                table: "Addresses",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalityId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_MunicipalityId",
                table: "Addresses");
        }
    }
}
